using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.WindowsAzure.TransientFaultHandling;
using Microsoft.Practices.TransientFaultHandling;
using Microsoft.Practices.Unity;
using SampleConsoleApplication.Services;
using SampleConsoleApplication.TransientErrors.Strategies;
using singleton = Microsoft.Practices.Unity.ContainerControlledLifetimeManager;

namespace SampleConsoleApplication
{
    class Program
    {
        static void Main()
        {
            // IoC to inject dependencies 
            var container = GetContainer();

            // Gets three implementation of IService. 
            var alwaysFailsService = container.Resolve<IService>();
            var writer = container.Resolve<OutputWriterService>();

            writer.WriteLine("Sample of Transient Fault Handling Block");

            writer.WriteLine("======================================================");
            RetryPolityUsingConfigFile(container, alwaysFailsService, writer);
            writer.WriteLine("======================================================");

            writer.WriteLine("======================================================");
            RetryPolityUsingCode(container, alwaysFailsService, writer);
            writer.WriteLine("======================================================");

            writer.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void RetryPolityUsingConfigFile(IUnityContainer container, IService service, OutputWriterService writer)
        {
            writer.WriteLine("Begin sample: RetryPolityUsingConfigFile");
            // Gets the current Retry Manager configuration
            var retryManager = EnterpriseLibraryContainer.Current.GetInstance<RetryManager>();

            // Asks for the default Retry Policy. Keep on mind that it's possible to ask for an specific one.
            var retryPolicy = retryManager.GetRetryPolicy<FileSystemTransientErrorDetectionStrategy>();
            try
            {
                // Do some work that may result in a transient fault.
                retryPolicy.ExecuteAction(service.DoSlowAndImportantTask);
            }
            catch (Exception exception)
            {
                // All the retries failed.
                writer.WriteLine("An Exception has been thrown:\n{0}", exception);
            }
            writer.WriteLine("End sample: RetryPolityUsingConfigFile");
        }

        private static void RetryPolityUsingCode(IUnityContainer container, IService service, OutputWriterService writer)
        {
            writer.WriteLine("Begin sample: RetryPolityUsingCode");
            // Define your retry strategy: retry 5 times, starting 1 second apart
            // and adding 2 seconds to the interval each retry.
            var retryStrategy = new Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));

            // Define your retry policy using the retry strategy and the Windows Azure storage
            // transient fault detection strategy.
            var retryPolicy = new RetryPolicy<FileSystemTransientErrorDetectionStrategy>(retryStrategy);


            try
            {
                // Do some work that may result in a transient fault.
                retryPolicy.ExecuteAction(service.DoSlowAndImportantTask);
            }
            catch (Exception exception)
            {
                // All the retries failed.
                writer.WriteLine("An Exception has been thrown:\n{0}", exception);
            }
            writer.WriteLine("End sample: RetryPolityUsingCode");
        }

        private static IUnityContainer _container;
        private static IUnityContainer GetContainer()
        {
            if (_container != null) return _container;

            _container = new UnityContainer();
            _container.RegisterType<OutputWriterService>(new singleton());
            _container.RegisterType<IService, AlwaysFailsService>(new singleton());

            return _container;
        }
    }
}

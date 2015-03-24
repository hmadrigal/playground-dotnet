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
        private static IBlockService _blockService;
        static void Main()
        {
            // IoC to inject dependencies 
            var container = GetContainer();

            // Gets three implementation of IService. 
            _blockService = container.Resolve<IBlockService>();
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.ConsoleTraceListener());

            System.Diagnostics.Trace.WriteLine("Sample of Transient Fault Handling Block");

            System.Diagnostics.Trace.WriteLine("======================================================");
            RetryPolityUsingConfigFile(container, _blockService);
            System.Diagnostics.Trace.WriteLine("======================================================");

            System.Diagnostics.Trace.WriteLine("======================================================");
            RetryPolityUsingCode(container, _blockService);
            System.Diagnostics.Trace.WriteLine("======================================================");

            System.Diagnostics.Trace.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void RetryPolityUsingConfigFile(IUnityContainer container, IBlockService service)
        {
            System.Diagnostics.Trace.WriteLine("Begin sample: RetryPolityUsingConfigFile");
            // Gets the current Retry Manager configuration
            var retryManager = EnterpriseLibraryContainer.Current.GetInstance<RetryManager>();

            // Asks for the default Retry Policy. Keep on mind that it's possible to ask for an specific one.
            var retryPolicy = retryManager.GetRetryPolicy<BlockServiceExceptionDetectionStrategy>();

            // Do some work that may result in a transient fault.
            System.Threading.Tasks.Parallel.For(0, 100, index =>
            {
                try
                {
                    retryPolicy.Retrying += OnRetryPolicyRetrying;
                    retryPolicy.ExecuteAction(() =>
                    {
                        _blockService.PutBlock(index.ToString(), index);
                    });
                    retryPolicy.Retrying -= OnRetryPolicyRetrying;
                }
                catch (Exception exception)
                {
                    // All the retries failed.
                    System.Diagnostics.Trace.WriteLine(string.Format("An Exception has been thrown:\n{0}", exception));
                }
            });

            System.Diagnostics.Trace.WriteLine("End sample: RetryPolityUsingConfigFile");
        }

        private static void OnRetryPolicyRetrying(object sender, RetryingEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("Retrying Sample: Count:{0} Delay:{1} LastError:{2}", e.CurrentRetryCount, e.Delay, e.LastException));

        }

        private static void RetryPolityUsingCode(IUnityContainer container, IBlockService service)
        {
            System.Diagnostics.Trace.WriteLine("Begin sample: RetryPolityUsingCode");
            // Define your retry strategy: retry 5 times, starting 1 second apart
            // and adding 2 seconds to the interval each retry.
            var retryStrategy = new Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));

            // Define your retry policy using the retry strategy and the Windows Azure storage
            // transient fault detection strategy.
            var retryPolicy = new RetryPolicy<BlockServiceExceptionDetectionStrategy>(retryStrategy);

            // Do some work that may result in a transient fault.
            System.Threading.Tasks.Parallel.For(0, 100, index =>
            {
                try
                {
                    retryPolicy.Retrying += OnRetryPolicyRetrying;
                    retryPolicy.ExecuteAction(() =>
                    {
                        _blockService.PutBlock(index.ToString(), index);
                    });
                    retryPolicy.Retrying -= OnRetryPolicyRetrying;
                }
                catch (Exception exception)
                {
                    // All the retries failed.
                    System.Diagnostics.Trace.WriteLine(string.Format("An Exception has been thrown:\n{0}", exception));
                }
            });

            System.Diagnostics.Trace.WriteLine("End sample: RetryPolityUsingCode");
        }


        private static IUnityContainer _container;
        private static IUnityContainer GetContainer()
        {
            if (_container != null) return _container;

            _container = new UnityContainer();
            _container.RegisterType<IBlockService, TranscientFaultyBlockService>(new singleton());
            return _container;
        }
    }
}

using System;
using ChainOfResponsability.Infrastructure.Repository;

using Microsoft.Practices.Unity;
using ContainerExtensions=Microsoft.Practices.Unity.UnityContainerExtensions;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace ChainOfResponsability
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			UnityBootStrap();
			//var userRepository = Microsoft.Practices.Unity.UnityContainerExtensions.Resolve<IUserRepository>(container);
			var userRepository =  ContainerExtensions.Resolve<IUserRepository>(container);
			Console.WriteLine ("Call Stack of Layers when invoking GetUserFullName(0):\n {0} ", userRepository.GetUserFullName(0));
		}
		
		public static IUnityContainer container;
		private static void UnityBootStrap()
        {
            container = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            #region Mappings based on the configuration file
            IUnityContainer currentContainer = container;
            foreach (var containerSection in section.Containers)
            {
                var nestedContainer = currentContainer.CreateChildContainer();
                Microsoft.Practices.Unity.Configuration.UnityContainerExtensions.LoadConfiguration(nestedContainer, section, containerSection.Name);
                currentContainer = nestedContainer;
            }
            container = currentContainer;
            #endregion

        }
	}
}


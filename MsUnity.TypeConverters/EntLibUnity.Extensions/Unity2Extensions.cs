
namespace EntLibUnity.Extensions
{
    using System;
    using System.Configuration;
    using System.Linq;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ContainerModel.Unity;
    using Microsoft.Practices.ServiceLocation;


    /// <summary>
    /// A collection of static methods that works on IUnityContainer
    /// </summary>
    public static class Unity2Extensions
    {
        /// <summary>
        /// Loads all the containers from the configuration file by creating a child-parent relationship
        /// for each given container.
        /// </summary>
        /// <param name="container">The first parent of the chain of containers</param>
        /// <param name="configurationSectionName">name of the configuration section to be loaded</param>
        /// <param name="reverseOrder">Whether load the containers from last to first or in reverse order based on the configuration file</param>
        /// <returns>The last child of the chain of containers</returns>
        public static IUnityContainer LoadContainerHierarchyFromSection(this IUnityContainer container, string configurationSectionName = "unity", bool reverseOrder = false)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            #region Mappings based on the configuration file

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection(configurationSectionName);
            var currentContainer = container;
            foreach (var containerSection in reverseOrder ? section.Containers.Reverse() : section.Containers)
            {
                var nestedContainer = currentContainer.CreateChildContainer();
                nestedContainer.LoadConfiguration(section, containerSection.Name);
                currentContainer = nestedContainer;
            }
            if (container.IsRegistered<IUnityContainer>())
            {
                container.UnregisterType<IUnityContainer>();
            }
            container.RegisterInstance(currentContainer);
            container = currentContainer;

            #endregion Mappings based on the configuration file

            return container;
        }

        /// <summary>
        /// Loads the specified section into a given container
        /// </summary>
        /// <param name="container"></param>
        /// <param name="configurationSectionName"></param>
        /// <returns></returns>
        public static IUnityContainer LoadContainerFromSection(this IUnityContainer container, string configurationSectionName = "unity")
        {
            if (container == null)
                throw new ArgumentNullException("container");
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection(configurationSectionName);
            Microsoft.Practices.Unity.Configuration.UnityContainerExtensions.LoadConfiguration(container, section);
            return container;
        }

        /// <summary>
        /// Load the known types of EntepriseLibrary into the UnityContainer. Optionally updates the Enterprise Library container with
        /// the wrapped container. 
        /// </summary>
        /// <para>http://msdn.microsoft.com/en-us/library/ff664535(v=pandp.50).aspx</para>
        /// <param name="container"></param>
        /// <param name="setEntepriseLibraryToUseIt">whether or not update the Enterprise Library container</param>
        /// <returns>A IUnityContainer with the Enterprise Library types into its container</returns>
        public static IUnityContainer LoadEnterpriseLibraryTypes(this IUnityContainer container, bool setEntepriseLibraryToUseIt =false)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            var unityConfiguratorContainer = new UnityContainerConfigurator(container);
            var configurationSourceFactory = ConfigurationSourceFactory.Create();
            EnterpriseLibraryContainer.ConfigureContainer(unityConfiguratorContainer, configurationSourceFactory);
            
            if (setEntepriseLibraryToUseIt)
            {
                IServiceLocator locator = new UnityServiceLocator(container);
                EnterpriseLibraryContainer.Current = locator;
            }
            return container;
        }

        /// <summary>
        /// Remove a registered type for a given container
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <returns></returns>
        public static bool UnregisterType<T>(this IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            var foundRegistration = container.Registrations.FirstOrDefault(r => r.RegisteredType == typeof(T));
            if (foundRegistration == null)
            {
                return false;
            }
            else
            {
                foundRegistration.LifetimeManager.RemoveValue();
                return true;
            }
        }

        /// <summary>
        /// Removes a set of types from a given container
        /// </summary>
        /// <param name="container"></param>
        /// <param name="types"></param>
        public static void UnregisterTypes(this IUnityContainer container, params Type[] types)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            var foundRegistrations = container.Registrations.Where(r => types.Contains(r.RegisteredType));
            foreach (var item in foundRegistrations)
            {
                item.LifetimeManager.RemoveValue();
            }
        }
    
        public static TContract TryResolve<TContract>(this IUnityContainer container)
        {
            if (container==null)
            {
                throw new ArgumentNullException("container");
            }
            TContract instance;
            try
            {
                instance = container.Resolve<TContract>();
            }
            catch
            {
                instance = default(TContract);
            }
            return instance;
        }
    }
}
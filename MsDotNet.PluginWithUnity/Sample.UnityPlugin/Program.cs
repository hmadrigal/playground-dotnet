using System.Text;
using Microsoft.Practices.Unity;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Sample.UnityPlugin.Contracts;

namespace Sample.UnityPlugin
{
    class Program
    {
        private static IUnityContainer GetContainer()
        {
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = "unity.config";
            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)config.GetSection("unity");
            var container = new UnityContainer();
            section.Configure(container);
            return container;
        }

        static void Main(string[] args)
        {
            IUnityContainer container = GetContainer();
            var myProvider = container.Resolve<IProvider>();
            System.Console.WriteLine("Provider Name:{0}", myProvider.Name);
            System.Console.ReadKey();
        }
    }
}
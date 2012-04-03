using System;
using System.Configuration;

namespace MultipleConfigurationFilesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = ConfigurationManager.AppSettings[ApplicationConstants.AppSettings.EnvironmentName];
            var serverSharedPath = ConfigurationManager.AppSettings[ApplicationConstants.AppSettings.ServerSharedPath];
            Console.WriteLine(@"Environment: {0} ServerSharedPath:{1}", environment, serverSharedPath);
            Console.ReadKey();
        }
    }
}

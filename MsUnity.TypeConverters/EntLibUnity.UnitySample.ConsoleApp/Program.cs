using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using EntLibUnity.Extensions;
using EntLibUnity.Infrastructure;

namespace EntLibUnity.UnitySample.ConsoleApp
{
    class Program
    {
        private static IUnityContainer container;

        static void Main(string[] args)
        {
            container =
                new UnityContainer()
                .LoadContainerFromSection()
                .LoadEnterpriseLibraryTypes();

            var versionManager = container.Resolve<IVersionManager>();
            Console.WriteLine(versionManager.Version);
            Console.ReadKey();
        }
    }
}

using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using AspectOriented.Infrastructure.Services;

namespace AspectOriented.Terminal
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Loads the container
			IUnityContainer container = new UnityContainer ();
			container = Microsoft.Practices.Unity.Configuration.UnityContainerExtensions.LoadConfiguration (container);
			
			// Resolve the proxy-sample
			var proxy = Microsoft.Practices.Unity.UnityContainerExtensions.Resolve<IProxy> (container);
			if (proxy.IsEnabled ()) {
				proxy.Open ();
			}
			proxy.Close ();
			
			// End of the test
			Console.ReadKey ();
		}
	}
}


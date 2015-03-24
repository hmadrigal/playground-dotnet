using System;
using AspectOriented.Infrastructure.Services;

namespace AspectOriented.Terminal.Services
{
	public class Proxy : IProxy
	{
		public Proxy ()
		{
		}

		#region IProxy implementation
		public bool IsEnabled ()
		{
			System.Console.WriteLine (String.Format ("[{0}:{1}]", this.GetType ().Name, "IsEnabled"));
			return true;
		}

		public void Open ()
		{
			System.Console.WriteLine (String.Format ("[{0}:{1}]", this.GetType ().Name, "Open"));
		}

		public void Close ()
		{
			System.Console.WriteLine (String.Format ("[{0}:{1}]", this.GetType ().Name, "Close"));
		}
		#endregion
	}
}


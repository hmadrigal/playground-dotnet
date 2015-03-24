using System;
namespace AspectOriented.Infrastructure.Services
{
	public interface IProxy
	{
		bool IsEnabled ();
		void Open ();
		void Close ();
	}
}


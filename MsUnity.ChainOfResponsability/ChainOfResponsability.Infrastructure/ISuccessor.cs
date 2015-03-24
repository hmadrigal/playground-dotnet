using System;
namespace ChainOfResponsability.Infrastructure
{
	public interface ISuccessor<T>
	{
		T Successor {get;}
	}
}


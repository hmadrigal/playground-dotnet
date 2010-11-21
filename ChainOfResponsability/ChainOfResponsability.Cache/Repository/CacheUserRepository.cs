using System;
using ChainOfResponsability.Infrastructure;
using ChainOfResponsability.Infrastructure.Repository;
using Microsoft.Practices.Unity;
using ContainerExtensions=Microsoft.Practices.Unity.UnityContainerExtensions;
namespace ChainOfResponsability.Cache.Repository
{
	public class CacheUserRepository : IUserRepository, ISuccessor<IUserRepository>
	{
		public CacheUserRepository (IUnityContainer container)
		{
			this.Successor = ContainerExtensions.Resolve<IUserRepository>(container.Parent);
		}
	
		#region IUserRepository implementation
		public string GetUserFullName (int id)
		{
			return string.Format("{0}->{1}",this.GetType().Name,this.Successor.GetUserFullName(id));
		}
		#endregion


		#region ISuccessor[IUserRepository] implementation
		public IUserRepository Successor {get;set;}
		#endregion
}
}


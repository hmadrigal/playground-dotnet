using System;
using ChainOfResponsability.Infrastructure.Repository;
using ChainOfResponsability.Infrastructure;
using ContainerExtensions=Microsoft.Practices.Unity.UnityContainerExtensions;
using Microsoft.Practices.Unity;
namespace ChainOfResponsability.Logging.Repository	
{
	public class LoggingUserRespository : IUserRepository, ISuccessor<IUserRepository>
	{
		public LoggingUserRespository (IUnityContainer container)
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
		public IUserRepository Successor  {get;set;}
		#endregion

}
}


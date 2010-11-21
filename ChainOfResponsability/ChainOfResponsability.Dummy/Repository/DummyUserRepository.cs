using System;
using ChainOfResponsability.Infrastructure;
using ChainOfResponsability.Infrastructure.Repository;
namespace ChainOfResponsability.Dummy.Repository
{
	public class DummyUserRepository : IUserRepository
	{
		public DummyUserRepository ()
		{
		}
	

		#region IUserRepository implementation
		public string GetUserFullName (int id)
		{
			return string.Format("{0}[{1}]",this.GetType().Name,id);
		}
		#endregion
}
}


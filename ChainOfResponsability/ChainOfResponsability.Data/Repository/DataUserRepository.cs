using System;
using ChainOfResponsability.Infrastructure;
using ChainOfResponsability.Infrastructure.Repository;
namespace ChainOfResponsability.Data.Repository
{
	public class DataUserRepository : IUserRepository
	{
		public DataUserRepository ()
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


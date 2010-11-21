using System;
namespace ChainOfResponsability.Infrastructure.Repository
{
	public interface IUserRepository
	{
		string GetUserFullName(int id);
	}
}


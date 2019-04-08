using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories.Base;
using System;

namespace Bolao.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
		User AuthUser(string email, string password);
		User GetUserByToken(Guid token);
        bool IsEmailExist(string email);
	}
}
using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories.Base;

namespace Bolao.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
		User AuthUser(string email, string password);
	}
}
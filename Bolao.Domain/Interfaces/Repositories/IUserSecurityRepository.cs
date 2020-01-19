using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories.Base;

namespace Bolao.Domain.Interfaces.Repositories
{
    public interface IUserSecurityRepository : IRepositoryBase<UserSecurity>
    {
        UserSecurity GetByEmail(string email);
    }
}
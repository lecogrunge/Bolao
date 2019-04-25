using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Bolao.Infra.Persistence.Repositories
{
	public sealed class UserSecurityRepository : RepositoryBase<UserSecurity>, IUserSecurityRepository
	{
		public UserSecurityRepository(BolaoContext bolaoContext) : base(bolaoContext) { }

		public UserSecurity GetByEmail(string email)
		{
			return base._context.UserSecurities.Include(s => s.User).FirstOrDefault(x => x.User.Email.EmailAddress == email);
		}
	}
}
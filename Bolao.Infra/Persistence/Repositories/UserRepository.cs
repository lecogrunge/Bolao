using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories.Base;
using System;
using System.Linq;

namespace Bolao.Infra.Persistence.Repositories
{
	public sealed class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(BolaoContext bolaoContext) : base(bolaoContext) { }

		public User AuthUser(string email, string password)
		{
			return _context.Users.FirstOrDefault(s => s.Password.Equals(email) && s.Password.Equals(password));
		}

		public User GetUserByToken(Guid token)
		{
			return _context.Users.FirstOrDefault(s => s.TokenConfirm == token);
		}
    }
}
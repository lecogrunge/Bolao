using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bolao.Infra.Persistence.Repositories
{
	public sealed class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(BolaoContext bolaoContext) : base(bolaoContext) { }

		public User AuthUser(string email, string password)
		{
			return base._context.Users.FirstOrDefault(s => s.Email.EmailAddress.Equals(email) && s.Password.Equals(password));
		}

		public User GetUserByToken(Guid token)
		{
			return base._context.Users.Include(s => s.UserSecurity).FirstOrDefault(s => s.UserSecurity.TokenCreateConfirmed == token);
		}

        public bool IsEmailExist(string email)
        {
            return base._context.Users.Any(s => s.Email.EmailAddress.Equals(email));
        }
    }
}
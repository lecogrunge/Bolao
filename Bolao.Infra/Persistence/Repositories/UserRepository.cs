using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Bolao.Infra.Persistence.Repositories
{
    public sealed class UserRepository : RepositoryBase<User, BolaoContext>, IUserRepository
    {
        public UserRepository(BolaoContext _context) : base(_context)
        {
        }

        public User AuthUser(string email, string password)
        {
            try
            {
                return base._context.Users.FirstOrDefault(s => s.Email.EmailAddress.Equals(email.ToLower()) && s.Password.Equals(password));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public User GetUserByTokenConfirmation(Guid token)
        {
            try
            {
                return base._context.Users.Include(s => s.UserSecurity).FirstOrDefault(s => s.UserSecurity.TokenCreateConfirmed == token);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public User GetUserByTokenForgotPassword(Guid token)
        {
            try
            {
                return base._context.Users.Include(s => s.UserSecurity).FirstOrDefault(s => s.UserSecurity.TokenForgotPassword == token);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public bool IsEmailExists(string email)
        {
            try
            {
                return base._context.Users.Any(s => s.Email.EmailAddress.Equals(email.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public bool VerifyUserIsActiveByEmail(string email)
        {
            try
            {
                return base._context.Users.Any(s => s.Email.EmailAddress.Equals(email.ToLower()) && s.Active.Equals(true));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }
    }
}
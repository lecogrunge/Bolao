using Bolao.CrossCutting.Common;
using Bolao.Domain.ObjectValue;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
	public sealed class User
    {
        #region Constructor
        protected User() { }

        public User(string fisrtName, string lastName, Email email, string password)
        {
            UserId = Guid.NewGuid();
            FisrtName = fisrtName;
            LastName = lastName;
            Email = email;
            Password = password;

            CreatedAt = DateTime.Now;
            Active = false;
			UserSecurity = new UserSecurity(UserId);
			UsersContactTypes = new HashSet<UserContactType>();
        }
        #endregion

        public Guid UserId { get; private set; }
		public string FisrtName { get; private set; }
		public string LastName { get; private set; }
		public Email Email { get; private set; }
		public string Password { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public bool Active { get; private set; }
		public ICollection<UserContactType> UsersContactTypes { get; set; }
		public UserSecurity UserSecurity { get; private set; }

        public void ActiveUser()
		{
			this.Active = true;
		}

        public void CryptPassword(string password)
        {
            this.Password = password.CryptPassword();
        }
    }
}
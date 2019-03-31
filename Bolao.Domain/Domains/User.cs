﻿using Bolao.Domain.ObjectValue;
using System;

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

            CreateDate = DateTime.Now;
            Active = false;
            TokenConfirm = Guid.NewGuid();
        }
        #endregion

        public Guid UserId { get; private set; }
		public string FisrtName { get; private set; }
		public string LastName { get; private set; }
		public Email Email { get; private set; }
		public string Password { get; private set; }
		public DateTime CreateDate { get; private set; }
		public bool Active { get; private set; }
		public Guid TokenConfirm { get; private set; }

        public void ActiveUser()
		{
			this.Active = true;
		}
    }
}
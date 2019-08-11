using System;

namespace Bolao.Domain.Domains
{
	public sealed class UserSecurity
	{
        protected UserSecurity() { }

		public UserSecurity(Guid userId)
		{
			this.UserId = userId;
			this.TokenCreateConfirmed = Guid.NewGuid();
		}

		public Guid UserSecurityId { get; private set; }
		public Guid TokenCreateConfirmed { get; private set; }
		public Guid? TokenForgotPassword { get; private set; }
		public Guid UserId { get; private set; }
		public User User { get; set; }

		public void GenerateTokenForgotPassword()
		{
			this.TokenForgotPassword = Guid.NewGuid();
		}
	}
}
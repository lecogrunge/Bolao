using System;

namespace Bolao.Domain.Domains
{
	public sealed class Security
	{
		public Security(Guid userId)
		{
			this.UserId = userId;
			this.HashCreateConfirmed = Guid.NewGuid();
		}

		public int SecurityId { get; private set; }
		public Guid HashCreateConfirmed { get; private set; }
		public Guid HashForgotPassword { get; private set; }
		public Guid UserId { get; private set; }
		public User User { get; private set; }
	}
}
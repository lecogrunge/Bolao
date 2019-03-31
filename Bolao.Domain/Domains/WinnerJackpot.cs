using System;

namespace Bolao.Domain.Domains
{
	public sealed class WinnerJackpot
	{
		protected WinnerJackpot() { }

		public WinnerJackpot(Guid idUser, Guid idTicket, decimal jackPot)
		{
			IdUser = idUser;
			IdTicket = idTicket;
			JackPot = jackPot;
		}

		public int IdWinner { get; private set; }
		public Guid IdUser { get; private set; }
		public Guid IdTicket { get; private set; }
		public decimal JackPot { get; private set; }
	}
}
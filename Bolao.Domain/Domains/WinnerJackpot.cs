using System;

namespace Bolao.Domain.Domains
{
	public sealed class WinnerJackpot
	{
        #region Constructor
        protected WinnerJackpot() { }

		public WinnerJackpot(Guid userId, Guid ticketId, decimal jackPot)
		{
			UserId = userId;
			TicketId = ticketId;
			JackPot = jackPot;
		}
        #endregion

        public int WinnerJackpotId { get; private set; }
        public decimal JackPot { get; private set; }

        public User User { get; private set; }
        public Guid UserId { get; private set; }

        public Ticket Ticket { get; private set; }
		public Guid TicketId { get; private set; }
	}
}
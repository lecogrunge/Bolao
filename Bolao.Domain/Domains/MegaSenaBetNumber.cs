using System;

namespace Bolao.Domain.Domains
{
	public sealed class MegaSenaBetNumber
    {
        #region Constructor
        protected MegaSenaBetNumber() { }

        public MegaSenaBetNumber(string number, Guid ticketId)
        {
            this.Number = number;
            this.TicketId = ticketId;
        }
        #endregion

        public int MegaSenaBetNumberId { get; private set; }
		public string Number { get; private set; }
		public Guid TicketId { get; private set; }

		public Ticket Ticket { get; private set; }
    }
}
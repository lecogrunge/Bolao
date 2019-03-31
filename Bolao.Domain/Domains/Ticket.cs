using Bolao.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
    public sealed class Ticket
    {
        #region Constructor
        protected Ticket() { }

        public Ticket(decimal price, bool active, DateTime startDateBet, DateTime endDateBet, EnumTypeBet typeBet)
        {
            this.TicketId = Guid.NewGuid();
            this.Price = price;
            this.Active = active;
            this.StartDateBet = startDateBet;
            this.EndDateBet = endDateBet;
            this.TypeBetId = typeBet;

            this.CreateDate = DateTime.Now;
        }
        #endregion

        public Guid TicketId { get; private set; }
		public decimal Price { get; private set; }
		public bool Active { get; private set; }
		public DateTime CreateDate { get; private set; }
		public DateTime StartDateBet { get; private set; }
		public DateTime EndDateBet { get; private set; }
		public EnumTypeBet TypeBetId { get; private set; }
		public EnumStatusPagSeguro StatusPagSeguro { get; private set; }

		public ICollection<MegaSenaBetNumber> ListBetNumbers { get; private set; }
    }
}
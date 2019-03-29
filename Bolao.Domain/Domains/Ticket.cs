using Bolao.Domain.Enum;
using System;
using System.Collections;

namespace Bolao.Domain.Domains
{
	public sealed class Ticket
    {
		public Guid IdTicket { get; private set; }
		public decimal Price { get; private set; }
		public bool Active { get; private set; }
		public DateTime CreateDate { get; private set; }
		public DateTime StartDateBet { get; private set; }
		public DateTime EndDateBet { get; private set; }
		public EnumTypeBet IdTypeBet { get; private set; }
		public EnumStatusPagSeguro StatusPagSeguro { get; private set; }

		public ICollection ListBetNumbers { get; private set; }

		protected Ticket() { }

		public Ticket(decimal price, bool active, DateTime startDateBet, DateTime endDateBet, EnumTypeBet typeBet)
		{
			this.IdTicket = Guid.NewGuid();
			this.Price = price;
			this.Active = active;
			this.StartDateBet = startDateBet;
			this.EndDateBet = endDateBet;
			this.IdTypeBet = typeBet;

			this.CreateDate = DateTime.Now;
		}
    }
}
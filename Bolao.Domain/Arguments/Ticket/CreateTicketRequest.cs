using Bolao.Domain.Enum;
using System;

namespace Bolao.Domain.Arguments.Ticket
{
	public sealed class CreateTicketRequest
	{
		public decimal Price { get; set; }
		public bool Active { get; set; }
		public DateTime EndDateBet { get; set; }
		public DateTime StartDateBet { get; set; }
		public EnumTypeBet TypeBet { get; set; }
	}
}
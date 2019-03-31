using Bolao.Domain.Arguments.Base;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Arguments.Ticket
{
	public sealed class ListTicketResponse : ResponseBase
	{
		public IEnumerable<ListTicket> ListTickets { get; set; }
	}

	public sealed class ListTicket
	{
		public Guid IdTicket { get; set; }
		public decimal Price { get; set; }
	}
}
using Bolao.Domain.Arguments.Base;
using System;

namespace Bolao.Domain.Arguments.Ticket
{
	public sealed class ListTicketResponse : ResponseBase
	{
		public Guid IdTicket { get; set; }
		public decimal Price { get; set; }
	}
}
using Bolao.Domain.Arguments.Ticket;
using Bolao.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace Bolao.Domain.Interfaces.Services
{
	public interface ITicketService : IServiceBase
	{
		CreateTicketResponse CreateTicket(CreateTicketRequest request);
		IAsyncEnumerable<ListTicketResponse> ListTicket(ListTicketRequest request);
	}
}
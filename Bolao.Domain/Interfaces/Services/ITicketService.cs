using Bolao.Domain.Arguments.Ticket;
using Bolao.Domain.Interfaces.Services.Base;

namespace Bolao.Domain.Interfaces.Services
{
	public interface ITicketService : IServiceBase
	{
		CreateTicketResponse CreateTicket(CreateTicketRequest request);
		ListTicketResponse ListTicket(ListTicketRequest request);
	}
}
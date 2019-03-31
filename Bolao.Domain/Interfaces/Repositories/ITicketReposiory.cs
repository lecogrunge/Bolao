using Bolao.Domain.Arguments.Ticket;
using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace Bolao.Domain.Interfaces.Repositories
{
	public interface ITicketReposiory : IRepositoryBase<Ticket>
	{
		IEnumerable<ListTicket> ListTickets(ListTicketRequest request);
	}
}
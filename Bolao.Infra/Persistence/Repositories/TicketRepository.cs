using Bolao.Domain.Arguments.Ticket;
using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Infra.Persistence.Repositories
{
	public sealed class TicketRepository : RepositoryBase<Ticket>, ITicketReposiory
	{
		public TicketRepository(BolaoContext bolaoContext) : base(bolaoContext) { }

		public IEnumerable<ListTicket> ListTickets(ListTicketRequest request)
		{
			return  _context.Tickets.Where(s => s.Active == request.Active)
									.Select(s => new ListTicket { IdTicket = s.IdTicket, Price = s.Price })
									.AsEnumerable();
		}
	}
}
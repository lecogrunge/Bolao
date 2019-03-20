using Bolao.Domain.Arguments.Ticket;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Bolao.Domain.Services
{
	public sealed class TicketService : ITicketService
	{
		private readonly ITicketReposiory _ticketRepository;

		public TicketService(ITicketReposiory ticketRepository)
		{
			_ticketRepository = ticketRepository;
		}

		public CreateTicketResponse CreateTicket(CreateTicketRequest request)
		{
			CreateTicketResponse response = new CreateTicketResponse();

			Ticket ticket = new Ticket(request.Price, request.Active, request.StartDateBet, request.EndDateBet, request.TypeBet);
			TicketValidator ticketValidator = new TicketValidator();
			ValidationResult ticketResult = ticketValidator.Validate(ticket);
			if (!ticketResult.IsValid)
				response.AddError(ticketResult);

			return response;
		}

		public IAsyncEnumerable<ListTicketResponse> ListTicket(ListTicketRequest request)
		{
			ListTicketResponse response = new ListTicketResponse();
			var tickets =   _ticketRepository.ListTickets(request);

			return tickets;
		}
	}
}
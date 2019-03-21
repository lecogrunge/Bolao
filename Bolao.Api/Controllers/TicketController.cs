using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.Ticket;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
	[Route("api/ticket")]
    [ApiController]
    public class TitcketController : BaseController
    {
        private readonly ITicketService _ticketService;

        public TitcketController(IUnitOfWork unitOfWork, ITicketService ticketService) : base(unitOfWork)
        {
            _ticketService = ticketService;            
        }

		[HttpGet]
		public async Task<IActionResult> ListTitckets(ListTicketRequest request)
		{
			ListTicketResponse response = _ticketService.ListTicket(request);

			return await ResponseAsync(response, response.IsValid(), response.GetErrors());
		}

		[HttpPost]
        public async Task<IActionResult> PostTitcket(CreateTicketRequest request)
        {
			CreateTicketResponse response = _ticketService.CreateTicket(request);

			return await ResponseAsync(response, response.IsValid(), response.GetErrors());
		}
	}
}
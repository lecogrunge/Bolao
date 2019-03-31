using Bolao.Api.Controllers.Base;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace Bolao.Api.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;

        public TicketController(IUnitOfWork unitOfWork, ITicketService ticketService) : base(unitOfWork)
        {
            _ticketService = ticketService;
        }
    }
}
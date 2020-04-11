using Bolao.Api.Controllers.Base;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : BaseController
    {
        private readonly ITicketService ticketService;

        public TicketController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        [HttpPost]
        [Route("MakeBet")]
        public async Task<IActionResult> MakeBet(MakeBetRequest request)
        {
            try
            {
                MakeBetResponse response = ticketService.MakeBet(request);

                if (response.IsValid())
                {
                    return Ok(response);
                }

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
        }
    }
}
using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.Titcket;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TitcketController : BaseController
    {
        private readonly ITitcketService _ticketService;

        public TitcketController(IUnitOfWork unityOfWork, ITitcketService ticketService) : base(unityOfWork)
        {
            _ticketService = ticketService;            
        }

		[HttpGet]
		public async Task<IActionResult> ListTitckets(ListTitcketRequest ticket)
		{
			ListTitcketResponse response = _ticketService.ListTitcket(ticket);

			if (response.IsValid())
			{
				try
				{
					_unitOfWork.Commit();
					return Ok(response);
				}
				catch (Exception ex)
				{
					return BadRequest(Msg.ErrorGeneric400);
				}
			}

			return BadRequest(response.GetErrors());
		}

		[HttpPost]
        public async Task<IActionResult> PostTitcket(CreateTitcketRequest ticket)
        {
            CreateTitcketResponse response = _ticketService.CreateTitcket(ticket);

            if (response.IsValid())
            {
                try
                {
                    _unitOfWork.Commit();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(Msg.ErrorGeneric400);
                }
            }

            return BadRequest(response.GetErrors());
        }

		[HttpPost]
		public async Task<IActionResult> AuthTitcket(AuthTitcketRequest auth)
		{
			AuthTitcketResponse response = _ticketService.AuthTitcket(auth);

			if (response.IsValid())
			{
				try
				{
					_unitOfWork.Commit();
					return Ok(response);
				}
				catch (Exception ex)
				{
					return BadRequest(Msg.ErrorGeneric400);
				}
			}

			return BadRequest(response.GetErrors());
		}
	}
}
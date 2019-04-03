using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
	[Route("api/lottery")]
	[ApiController]
	public class LotteryController : BaseController
	{
		private readonly ILotteryService _ticketService;

		public LotteryController(IUnitOfWork unitOfWork, ILotteryService ticketService) : base(unitOfWork)
		{
			_ticketService = ticketService;
		}

		[HttpGet]
		public async Task<IActionResult> ListLotteries(ListLotteryRequest request)
		{
			ListLotteryResponse response = _ticketService.ListLottery(request);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpPost]
		public async Task<IActionResult> CreateLottery(CreateLotteryRequest request)
		{
			CreateLotteryResponse response = _ticketService.CreateLottery(request);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpPost]
		public async Task<IActionResult> InsertNumbersLotteryResult(CreateLotteryRequest request)
		{
			CreateLotteryResponse response = _ticketService.CreateLottery(request);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}
	}
}
using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("lottery")]
    [ApiController]
    public class LotteryController : BaseController
    {
        private readonly ILotteryService lotteryService;

        public LotteryController(ILotteryService lotteryService)
        {
            this.lotteryService = lotteryService;
        }

        [HttpGet]
        public async Task<IActionResult> ListLotteries(bool active)
        {
            ListLotteryResponse response = lotteryService.ListLottery(active);

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response.GetErrors());
        }

        [HttpPost]
        public async Task<IActionResult> CreateLottery(CreateLotteryRequest request)
        {
            CreateLotteryResponse response = lotteryService.CreateLottery(request);

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response.GetErrors());
        }

        [HttpPost("InsertNumbersLotteryResult")]
        public async Task<IActionResult> InsertNumbersLotteryResult(NumberLotteryRequest request)
        {
            NumberLotteryResponse response = lotteryService.InsertNumbersLotteryResult(request);

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response.GetErrors());
        }
    }
}
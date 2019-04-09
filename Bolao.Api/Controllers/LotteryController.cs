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
        private readonly ILotteryService _lotteryService;

        public LotteryController(IUnitOfWork unitOfWork, ILotteryService lotteryService) : base(unitOfWork)
        {
            _lotteryService = lotteryService;
        }

        [HttpGet]
        public async Task<IActionResult> ListLotteries(bool active)
        {
            ListLotteryResponse response = _lotteryService.ListLottery(active);

            if (response.IsValid())
                return await ResponseAsync(response);

            return BadRequest(response.GetErrors());
        }

        [HttpPost]
        public async Task<IActionResult> CreateLottery(CreateLotteryRequest request)
        {
            CreateLotteryResponse response = _lotteryService.CreateLottery(request);

            if (response.IsValid())
                return await ResponseAsync(response);

            return BadRequest(response.GetErrors());
        }

        [HttpPost("InsertNumbersLotteryResult")]
        public async Task<IActionResult> InsertNumbersLotteryResult(NumberLotteryRequest request)
        {
            NumberLotteryResponse response = _lotteryService.InsertNumbersLotteryResult(request);

            if (response.IsValid())
                return await ResponseAsync(response);

            return BadRequest(response.GetErrors());
        }
    }
}
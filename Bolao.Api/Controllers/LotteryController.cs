using Bolao.Api.Controllers.Base;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("api/lottery")]
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
            try
            {
                ListLotteryResponse response = lotteryService.ListLottery(active);

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

        [HttpPost]
        public async Task<IActionResult> CreateLottery(CreateLotteryRequest request)
        {
            try
            {
                CreateLotteryResponse response = lotteryService.CreateLottery(request);

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

        [HttpPost("InsertNumbersLotteryResult")]
        public async Task<IActionResult> InsertNumbersLotteryResult(NumberLotteryRequest request)
        {
            try
            {
                NumberLotteryResponse response = lotteryService.InsertNumbersLotteryResult(request);

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
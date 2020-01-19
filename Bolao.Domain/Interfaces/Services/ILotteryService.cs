using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services.Base;

namespace Bolao.Domain.Interfaces.Services
{
    public interface ILotteryService : IServiceBase
    {
        CreateLotteryResponse CreateLottery(CreateLotteryRequest request);

        ListLotteryResponse ListLottery(bool active);

        NumberLotteryResponse InsertNumbersLotteryResult(NumberLotteryRequest request);
    }
}
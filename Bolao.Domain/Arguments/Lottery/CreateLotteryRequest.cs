using Bolao.Domain.Arguments.Base;
using Bolao.Domain.Enum;
using System;

namespace Bolao.Domain.Arguments.Lottery
{
    public sealed class CreateLotteryRequest : BaseRequest
    {
        public decimal Price { get; private set; }
        public DateTime EndDateBet { get; private set; }
        public DateTime StartDateBet { get; private set; }
        public DateTime LotteryDateBet { get; private set; }
        public EnumTypeBet TypeBetId { get; private set; }
    }
}
using Bolao.Domain.Arguments.Base;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Arguments.Lottery
{
    public sealed class ListLotteryResponse : ResponseBase
    {
        public IEnumerable<ListLottery> ListLotteries { get; set; }
    }

    public sealed class ListLottery
    {
        public Guid LotteryId { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDateBet { get; set; }
        public DateTime EndDateBet { get; set; }
        public DateTime LotteryDateBet { get; set; }
        public string TypeBet { get; set; }
    }
}
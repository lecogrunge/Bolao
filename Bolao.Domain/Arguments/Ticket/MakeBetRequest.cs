using System;
using System.Collections.Generic;

namespace Bolao.Domain.Arguments.Lottery
{
    public sealed class MakeBetRequest
    {
        public Guid LotteryId { get; set; }

        public ICollection<BetNumber> BetNumbers { get; set; }

        public struct BetNumber
        {
            public string[] Numbers { get; set; }
        }
    }
}
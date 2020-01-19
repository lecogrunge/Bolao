using System;

namespace Bolao.Domain.Domains
{
    public sealed class OwnerJackpot
    {
        #region Constructor

        protected OwnerJackpot()
        {
        }

        public OwnerJackpot(Guid lotteryId, decimal jackpot, decimal profit)
        {
            LotteryId = lotteryId;
            Jackpot = jackpot;
            Profit = profit;
        }

        #endregion Constructor

        public int OwnerJackpotId { get; private set; }
        public decimal Jackpot { get; private set; }
        public decimal Profit { get; private set; }

        public Guid LotteryId { get; private set; }
        public Lottery Lottery { get; private set; }
    }
}
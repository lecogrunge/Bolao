using System;

namespace Bolao.Domain.Domains
{
    public sealed class LotteryNumberResult
    {
        #region Constructor

        protected LotteryNumberResult()
        {
        }

        public LotteryNumberResult(string number, Guid lotteryId)
        {
            Number = number;
            LoterryId = lotteryId;
        }

        #endregion Constructor

        public int LotteryNumberResultId { get; private set; }
        public string Number { get; private set; }

        public Guid LoterryId { get; private set; }
        public Lottery Lottery { get; private set; }
    }
}
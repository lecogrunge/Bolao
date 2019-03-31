using System;

namespace Bolao.Domain.Domains
{
    public sealed class LotteryNumberResult
    {
        #region Constructor
        protected LotteryNumberResult() { }

        public LotteryNumberResult(string number, Guid lotteryId)
        {
            this.Number = number;
            this.LoterryId = lotteryId;
        }
        #endregion
        public int LotteryNumberResultId { get; private set; }
        public string Number { get; private set; }

        public Guid LoterryId { get; private set; }
        public Lottery Lottery { get; private set; }        
    }
}
using System;

namespace Bolao.Domain.Domains
{
	public sealed class MegaSenaBetNumber
    {
        #region Constructor
        protected MegaSenaBetNumber() { }

        public MegaSenaBetNumber(string number, Guid ticketId)
        {
            this.Number = number;
            this.LotteryId = ticketId;
        }
        #endregion

        public int MegaSenaBetNumberId { get; private set; }
		public string Number { get; private set; }
		public Guid LotteryId { get; private set; }

		public Lottery Lottery { get; private set; }
    }
}
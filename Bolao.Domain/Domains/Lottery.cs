using Bolao.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
    public sealed class Lottery
    {
        #region Constructor
        protected Lottery() { }

        public Lottery(decimal price, DateTime startDateBet, DateTime endDateBet, DateTime lotteryDateBet, int typeBetId)
        {
            this.LoterryId = Guid.NewGuid();
            this.Price = price;
            this.StartDateBet = startDateBet;
            this.EndDateBet = endDateBet;
            this.TypeBetId = typeBetId;
			this.LotteryDateBet = lotteryDateBet;
            this.CreatedAt = DateTime.Now;

			this.ListNumbersResult = new List<LotteryNumberResult>();
        }
        #endregion

        public Guid LoterryId { get; private set; }
		public decimal Price { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime StartDateBet { get; private set; }
		public DateTime EndDateBet { get; private set; }
		public DateTime LotteryDateBet { get; private set; }
		public EnumStatusPagSeguro StatusPagSeguro { get; private set; }

		public TypeBet TypeBet { get; private set; }
		public int TypeBetId { get; private set; }

		public ICollection<LotteryNumberResult> ListNumbersResult { get; private set; }
    }
}
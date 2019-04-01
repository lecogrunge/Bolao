using Bolao.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
    public sealed class Lottery
    {
        #region Constructor
        protected Lottery() { }

        public Lottery(decimal price, DateTime startDateBet, DateTime endDateBet, int typeBetId)
        {
            this.LoterryId = Guid.NewGuid();
            this.Price = price;
            this.StartDateBet = startDateBet;
            this.EndDateBet = endDateBet;
            this.TypeBetId = typeBetId;

            this.CreatedAt = DateTime.Now;
        }
        #endregion

        public Guid LoterryId { get; private set; }
		public decimal Price { get; private set; }
		public DateTime CreatedAt { get; private set; }
		public DateTime StartDateBet { get; private set; }
		public DateTime EndDateBet { get; private set; }
		public EnumStatusPagSeguro StatusPagSeguro { get; private set; }

		public TypeBet TypeBet { get; private set; }
		public int TypeBetId { get; private set; }

		public ICollection<LotteryNumberResult> ListNumbersResult { get; private set; }
    }
}
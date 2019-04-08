using System;

namespace Bolao.Domain.Domains
{
    public sealed class Buy
    {
        public Guid BuyId { get; private set; }
        public decimal Total { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int TotalTicket { get; private set; }

        public Guid LotteryId { get; private set; }
        public Lottery Lottery { get; private set; }
		
		public Guid UserId { get; private set; }
		public User User { get; private set; }
	}
}
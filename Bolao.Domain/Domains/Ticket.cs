using System;

namespace Bolao.Domain.Domains
{
    public sealed class Ticket
    {
        protected Ticket()
        {
        }

        public Guid TicketId { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Guid LotteryId { get; private set; }
        public Lottery Lottery {get; private set;}

        public int BuyId { get; private set; }
        public Buy Buy { get; private set; }
    }
}
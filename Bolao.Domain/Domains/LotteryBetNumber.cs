using System;

namespace Bolao.Domain.Domains
{
    public sealed class LotteryNumberBet
    {
        #region Constructor

        protected LotteryNumberBet()
        {
        }

        public LotteryNumberBet(string number, Guid ticketId)
        {
            Number = number;
            TicketId = ticketId;
        }

        #endregion Constructor

        public int LotteryNumberBetId { get; private set; }
        public string Number { get; private set; }

        public Guid TicketId { get; private set; }
        public Ticket Ticket { get; private set; }
    }
}
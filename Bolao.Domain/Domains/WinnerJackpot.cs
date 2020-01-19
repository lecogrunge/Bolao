using System;

namespace Bolao.Domain.Domains
{
    public sealed class WinnerJackpot
    {
        #region Constructor

        protected WinnerJackpot()
        {
        }

        public WinnerJackpot(Guid userId, Guid ticketId, decimal jackPot)
        {
            UserId = userId;
            LotteryId = ticketId;
            JackPot = jackPot;
        }

        #endregion Constructor

        public int WinnerJackpotId { get; private set; }
        public decimal JackPot { get; private set; }

        public User User { get; private set; }
        public Guid UserId { get; private set; }

        public Lottery Lottery { get; private set; }
        public Guid LotteryId { get; private set; }
    }
}
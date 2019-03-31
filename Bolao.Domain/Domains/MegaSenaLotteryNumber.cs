using System;

namespace Bolao.Domain.Domains
{
    public sealed class MegaSenaLotteryNumber
    {
        #region Constructor
        protected MegaSenaLotteryNumber() { }

        public MegaSenaLotteryNumber(string number, Guid idMegaSenaLoterry)
        {
            this.Number = number;
            this.MegaSenaLoterryId = idMegaSenaLoterry;
        }
        #endregion

        public int MegaSenaLoterryNumberId { get; private set; }
		public string Number { get; private set; }

        public Guid MegaSenaLoterryId { get; private set; }
        public MegaSenaLottery MegaSenaLottery { get; private set; }
    }
}
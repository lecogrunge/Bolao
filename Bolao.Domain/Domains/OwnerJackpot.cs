using System;

namespace Bolao.Domain.Domains
{
	public sealed class OwnerJackpot
	{
        #region Constructor
        protected OwnerJackpot() { }

		public OwnerJackpot(Guid megaSenaLoterryId, decimal jackpot)
		{
			MegaSenaLoterryId = megaSenaLoterryId;
			Jackpot = jackpot;
		}
        #endregion

        public int OwnerJackpotId { get; private set; }
		public Guid MegaSenaLoterryId { get; private set; }
		public decimal Jackpot { get; private set; }
        public decimal Profit { get; private set; }

        public MegaSenaLottery MegaSenaLottery { get; private set; }
	}
}
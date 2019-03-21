using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
	public sealed class MegaSenaLottery
    {
        public Guid IdMegaSenaLoterry { get; private set; }
        public DateTime LoterryDate { get; private set; }

		public ICollection<MegaSenaLotteryNumber> ListNumbers { get; private set; }

		public MegaSenaLottery(DateTime loterryDate)
		{
			this.IdMegaSenaLoterry = Guid.NewGuid();
			this.LoterryDate = loterryDate;
		}

		public void AddNumber(MegaSenaLotteryNumber number)
		{
			this.ListNumbers.Add(number);
		}
    }
}
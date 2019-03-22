using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
	public sealed class MegaSenaLottery
    {
		protected MegaSenaLottery() { }

		public MegaSenaLottery(DateTime loterryDate)
		{
			this.IdMegaSenaLoterry = Guid.NewGuid();
			this.LoterryDate = loterryDate;
		}

		public Guid IdMegaSenaLoterry { get; private set; }
        public DateTime LoterryDate { get; private set; }

		public ICollection<MegaSenaLotteryNumber> ListNumbers { get; private set; }

		public void AddNumber(MegaSenaLotteryNumber number)
		{
			if(this.ListNumbers.Count < 6)
				this.ListNumbers.Add(number);
		}
    }
}
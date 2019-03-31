using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
	public sealed class MegaSenaLottery
    {
		public Guid IdMegaSenaLoterry { get; private set; }
		public DateTime LoterryDate { get; private set; }
		public DateTime CreateDate { get; private set; }
		public int LoterryOfficialNumberBet { get; private set; }
		public ICollection<MegaSenaLotteryNumber> ListNumbers { get; private set; }


		protected MegaSenaLottery() { }

		public MegaSenaLottery(DateTime loterryDate)
		{
			this.IdMegaSenaLoterry = Guid.NewGuid();
			this.LoterryDate = loterryDate;
			this.CreateDate = DateTime.Now;
		}

		public void AddNumber(MegaSenaLotteryNumber number)
		{
			if(this.ListNumbers.Count < 6)
				this.ListNumbers.Add(number);
		}
    }
}
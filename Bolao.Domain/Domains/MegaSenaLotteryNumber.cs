using System;

namespace Bolao.Domain.Domains
{
    public sealed class MegaSenaLotteryNumber
    {
		public int IdMegaSenaLoterryNumber { get; private set; }
		public string Number { get; private set; }
		public Guid IdMegaSenaLoterry { get; private set; }


		protected MegaSenaLotteryNumber() { }

		public MegaSenaLotteryNumber(string number, Guid idMegaSenaLoterry)
		{
			this.Number = number;
			this.IdMegaSenaLoterry = idMegaSenaLoterry;
		}
    }
}
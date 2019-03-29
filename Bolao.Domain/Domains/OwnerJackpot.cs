using System;

namespace Bolao.Domain.Domains
{
	public sealed class OwnerJackpot
	{
		protected OwnerJackpot() { }

		public OwnerJackpot(Guid idMegaSenaLoterry, decimal jackpot)
		{
			IdMegaSenaLoterry = idMegaSenaLoterry;
			Jackpot = jackpot;
		}

		public int IdOwnerJackpot { get; private set; }
		public Guid IdMegaSenaLoterry { get; private set; }
		public decimal Jackpot { get; private set; }
	}
}
using System;

namespace Bolao.Domain.Arguments.MegaSenaLoterry
{
	public sealed class CreateMegaSenaRequest
	{
		public DateTime LoterryDate { get; set; }
		public string[] BetNumbers { get; set; }
	}
}
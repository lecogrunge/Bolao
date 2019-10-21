using Bolao.Domain.Arguments.Base;
using System;

namespace Bolao.Domain.Arguments.MegaSenaLoterry
{
	public sealed class CreateMegaSenaRequest : BaseRequest
    {
		public DateTime LoterryDate { get; set; }
		public string[] BetNumbers { get; set; }
	}
}
using System;

namespace Bolao.Domain.Arguments.Lottery
{
	public sealed class NumberLotteryRequest
	{
		public Guid LotteryId { get; set; }
		public string[] Numbers { get; set; }
	}
}
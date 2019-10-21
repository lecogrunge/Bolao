using Bolao.Domain.Arguments.Base;
using System;

namespace Bolao.Domain.Arguments.Lottery
{
	public sealed class NumberLotteryRequest : BaseRequest
    {
		public Guid LotteryId { get; set; }
		public string[] Numbers { get; set; }
	}
}
using System;

namespace Bolao.Domain.Arguments.Lottery
{
	public sealed class MakeBetRequest
	{
		public Guid LotteryId { get; set; }
		public decimal LotteryPrice { get; set; }
		public decimal TotalUnitBet { get; set; }
		public Guid UserId { get; set; }

		public string[] BetNumbers { get; set; }
	}
}
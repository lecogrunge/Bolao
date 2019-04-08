using Bolao.Domain.Enum;
using System;

namespace Bolao.Domain.Arguments.Lottery
{
	public sealed class CreateLotteryRequest
	{
		public decimal Price { get; set; }
        public DateTime EndDateBet { get; set; }
		public DateTime StartDateBet { get; set; }
		public DateTime LotteryDateBet { get; set; }
		public EnumTypeBet TypeBetId { get; set; }
	}
}
using Bolao.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
    public sealed class Lottery
    {
        #region Constructor

        public Lottery(decimal price, DateTime startDateBet, DateTime endDateBet, DateTime lotteryDateBet, int typeBetId)
        {
            LoterryId = Guid.NewGuid();
            Price = price;
            StartDateBet = startDateBet;
            EndDateBet = endDateBet;
            TypeBetId = typeBetId;
            LotteryDateBet = lotteryDateBet;
            CreatedAt = DateTime.Now;

            ListNumbersResult = new List<LotteryNumberResult>();
        }

        #endregion Constructor

        public Guid LoterryId { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime StartDateBet { get; private set; }
        public DateTime EndDateBet { get; private set; }
        public DateTime LotteryDateBet { get; private set; }
        public EnumStatusPagSeguro StatusPagSeguro { get; private set; }

        public TypeBet TypeBet { get; private set; }
        public int TypeBetId { get; private set; }

        public ICollection<LotteryNumberResult> ListNumbersResult { get; private set; }

        public void SetNumberInListLottery(LotteryNumberResult number)
        {
            ListNumbersResult.Add(number);
        }
    }
}
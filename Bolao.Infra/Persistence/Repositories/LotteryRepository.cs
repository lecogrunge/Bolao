using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Infra.Persistence.Repositories
{
	public sealed class LotteryRepository : RepositoryBase<Lottery, BolaoContext>, ILotteryReposiory
	{
		public LotteryRepository(BolaoContext bolaoContext) : base(bolaoContext) { }

        /// <summary>
        /// Retrieve all active lotteries
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
		public IEnumerable<ListLottery> ListLotteries(bool active)
		{
			return  _context.Lotteries.AsNoTracking()
                                      .Where(s => s.StartDateBet <= DateTime.Now && s.EndDateBet >= DateTime.Now)
									  .Select(s => new ListLottery { LotteryId = s.LoterryId, Price = s.Price })
									  .ToList();
		}

        public Lottery FindLottery(Guid lotteryId)
        {
            return _context.Lotteries.Include(s => s.TypeBet).FirstOrDefault(s => s.LoterryId == lotteryId);
        }
	}
}
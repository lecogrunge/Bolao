using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Infra.Persistence.EF;
using Bolao.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolao.Infra.Persistence.Repositories
{
	public sealed class LotteryRepository : RepositoryBase<Lottery>, ILotteryReposiory
	{
		public LotteryRepository(BolaoContext bolaoContext) : base(bolaoContext) { }

		public IEnumerable<ListLottery> ListLotteries(ListLotteryRequest request)
		{
			return  _context.Lotteries.Where(s => s.StartDateBet <= DateTime.Now && s.EndDateBet >= DateTime.Now)
									.Select(s => new ListLottery { LotteryId = s.LoterryId, Price = s.Price })
									.AsEnumerable();
		}
	}
}
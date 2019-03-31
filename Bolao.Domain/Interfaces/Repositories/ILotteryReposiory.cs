using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories.Base;
using System.Collections.Generic;

namespace Bolao.Domain.Interfaces.Repositories
{
	public interface ILotteryReposiory : IRepositoryBase<Lottery>
	{
		IEnumerable<ListLottery> ListLotteries(ListLotteryRequest request);
	}
}
using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services;

namespace Bolao.Domain.Services
{
	public sealed class TicketService : ITicketService
	{
		public MakeBetResponse MakeBet(MakeBetRequest request)
		{
            MakeBetResponse response = new MakeBetResponse();

            foreach (var item in request.BetNumbers)
            {
                
            }

            return response;
		}
	}
}
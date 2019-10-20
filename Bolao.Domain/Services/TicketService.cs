using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services;
using System;
using System.Reflection;

namespace Bolao.Domain.Services
{
	public sealed class TicketService : ITicketService
	{
		public MakeBetResponse MakeBet(MakeBetRequest request)
		{
            MakeBetResponse response = new MakeBetResponse();

            try
            {
                foreach (var item in request.BetNumbers)
                {

                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }
	}
}
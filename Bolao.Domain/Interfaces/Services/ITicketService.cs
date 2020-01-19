using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Interfaces.Services.Base;

namespace Bolao.Domain.Interfaces.Services
{
    public interface ITicketService : IServiceBase
    {
        MakeBetResponse MakeBet(MakeBetRequest request);
    }
}
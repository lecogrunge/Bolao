using Bolao.Domain.Arguments.MegaSenaLoterry;
using Bolao.Domain.Interfaces.Services.Base;

namespace Bolao.Domain.Interfaces.Services
{
	public interface IMegaSenaService : IServiceBase
	{
		CreateMegaSenaResponse CreateMegaSena(CreateMegaSenaRequest request);
	}
}
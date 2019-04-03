using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services.Base;

namespace Bolao.Domain.Interfaces.Services
{
	public interface IContactService : IServiceBase
	{
		ContactResponse Contact(ContactRequest request);
	}
}
using Bolao.Domain.Arguments.Contact;
using Bolao.Domain.Interfaces.Services.Base;

namespace Bolao.Domain.Interfaces.Services
{
    public interface IContactService : IServiceBase
    {
        ContactResponse Contact(ContactRequest request);
    }
}
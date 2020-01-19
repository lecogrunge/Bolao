using Bolao.Domain.Arguments.Base;

namespace Bolao.Domain.Arguments.Contact
{
    public sealed class ContactRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
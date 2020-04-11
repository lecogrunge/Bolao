using Bolao.Domain.Arguments.Base;

namespace Bolao.Domain.Arguments.Contact
{
    public sealed class ContactRequest : BaseRequest
    {
        public ContactRequest(string name, string email, string subject, string message)
        {
            Name = name.ToLower().Trim();
            Email = email.Trim();
            Subject = subject.Trim();
            Message = message.Trim();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }
    }
}
namespace Bolao.Domain.ObjectValue
{
    public sealed class Email
    {
        protected Email()
        {
        }

        public Email(string address)
        {
            EmailAddress = address;
        }

        public string EmailAddress { get; private set; }
    }
}
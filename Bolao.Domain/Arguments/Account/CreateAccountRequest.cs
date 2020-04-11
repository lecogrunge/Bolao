using Bolao.Domain.Arguments.Base;

namespace Bolao.Domain.Arguments.User
{
    public sealed class CreateAccountRequest : BaseRequest
    {
        public CreateAccountRequest(string fisrtName, string lastName, string email, string password)
        {
            FisrtName = fisrtName.ToLower().Trim();
            LastName = lastName.ToLower().Trim();
            Email = email.ToLower().Trim();
            Password = password.ToLower().Trim();
        }

        public string FisrtName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
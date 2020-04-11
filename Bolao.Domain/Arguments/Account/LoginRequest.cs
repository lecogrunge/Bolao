namespace Bolao.Domain.Arguments.User
{
    public sealed class LoginRequest
    {
        public LoginRequest(string email, string password)
        {
            this.Email = email.ToLower().Trim();
            this.Password = password;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
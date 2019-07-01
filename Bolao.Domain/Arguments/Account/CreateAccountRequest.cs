namespace Bolao.Domain.Arguments.User
{
    public sealed class CreateAccountRequest
    {
        public string FisrtName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
    }
}
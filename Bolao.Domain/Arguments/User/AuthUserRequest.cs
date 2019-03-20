namespace Bolao.Domain.Arguments.User
{
	public sealed class AuthUserRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
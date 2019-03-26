namespace Bolao.Domain.Arguments.User
{
	public sealed class ContactRequest
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
	}
}
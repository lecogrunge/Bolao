namespace Bolao.Domain.Domains
{
	public sealed class Bank
	{
		protected Bank() { }

		public Bank(string name)
		{
			Name = name;
		}

		public int IdBank { get; private set; }
		public string Name { get; private set; }
	}
}
namespace Bolao.Domain.Domains
{
    public sealed class TypeBet
	{
		public int IdTypeBet { get; private set; }
		public string Description { get; private set; }


		protected TypeBet() { }

		public TypeBet(string description)
		{
			this.Description = description;
		}
    }
}
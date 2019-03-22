namespace Bolao.Domain.Domains
{
    public sealed class TypeBet
    {
		protected TypeBet() { }

		public TypeBet(string description)
		{
			this.Description = description;
		}

        public int IdTypeBet { get; private set; }
        public string Description { get; private set; }
    }
}
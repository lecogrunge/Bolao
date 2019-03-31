namespace Bolao.Domain.Domains
{
    public sealed class TypeBet
	{
        #region Constructor
        protected TypeBet() { }

		public TypeBet(string description)
		{
			this.Description = description;
		}
        #endregion

        public int TypeBetId { get; private set; }
        public string Description { get; private set; }
    }
}
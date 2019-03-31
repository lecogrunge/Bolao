namespace Bolao.Domain.Domains
{
    public sealed class TypeBet
	{
        #region Constructor
        protected TypeBet() { }

		public TypeBet(string title)
		{
			this.Title = title;
		}
        #endregion

        public int TypeBetId { get; private set; }
        public string Title { get; set; }
        public string Description { get; private set; }
    }
}
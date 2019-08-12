namespace Bolao.Domain.Domains
{
    public sealed class TypeBet
	{
        #region Constructor
        protected TypeBet() { }

		public TypeBet(string title, string description, int countNumberResult, int countNumberBet)
		{
			this.Title = title;
            this.Description = description;
            this.CountNumberResult = countNumberResult;
            this.CountNumberBet = countNumberBet;
		}
        #endregion

        public int TypeBetId { get; private set; }
        public string Title { get; set; }
        public string Description { get; private set; }
        public int CountNumberResult { get; private set; }
        public int CountNumberBet { get; private set; }
    }
}
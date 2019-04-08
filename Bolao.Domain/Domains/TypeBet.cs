namespace Bolao.Domain.Domains
{
    public sealed class TypeBet
	{
        #region Constructor
        protected TypeBet() { }

		public TypeBet(string title, string description)
		{
			this.Title = title;
            this.Description = description;
		}
        #endregion

        public void SetId(int id)
        {
            this.TypeBetId = id;
        }

        public int TypeBetId { get; private set; }
        public string Title { get; set; }
        public string Description { get; private set; }
    }
}
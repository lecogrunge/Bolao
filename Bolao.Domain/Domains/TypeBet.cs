namespace Bolao.Domain.Domains
{
    public sealed class TypeBet
    {
        #region Constructor

        protected TypeBet()
        {
        }

        public TypeBet(string title, string description, int countNumberResult, int countNumberBet)
        {
            Title = title;
            Description = description;
            CountNumberResult = countNumberResult;
            CountNumberBet = countNumberBet;
        }

        #endregion Constructor

        public int TypeBetId { get; private set; }
        public string Title { get; set; }
        public string Description { get; private set; }
        public int CountNumberResult { get; private set; }
        public int CountNumberBet { get; private set; }
    }
}
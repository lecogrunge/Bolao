namespace Bolao.Domain.Domains
{
    public sealed class Bank
    {
        #region Constructor

        protected Bank()
        {
        }

        public Bank(string name)
        {
            Name = name;
        }

        #endregion Constructor

        public int BankId { get; private set; }
        public string Name { get; private set; }
    }
}
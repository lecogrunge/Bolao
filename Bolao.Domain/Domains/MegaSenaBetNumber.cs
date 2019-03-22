using System;

namespace Bolao.Domain.Domains
{
	public sealed class MegaSenaBetNumber
    {
		protected MegaSenaBetNumber() { }

		public MegaSenaBetNumber(string number, Guid idTicket)
		{
			this.Number = number;
			this.IdTicket = idTicket;
		}

        public int IdMegaSenaBetNumber { get; private set; }
        public string Number { get; private set; }

        public Guid IdTicket { get; private set; }
    }
}
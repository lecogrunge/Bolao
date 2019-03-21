using System;

namespace Bolao.Domain.Domains
{
	public sealed class MegaSenaBetNumber
    {
        public int IdMegaSenaBetNumber { get; private set; }
        public string Number { get; private set; }

        public Guid IdTicket { get; private set; }
    }
}
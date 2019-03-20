using System;

namespace Bolao.Domain.Domains
{
    public sealed class Ticket
    {
        public int IdTicket { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime StartDateBet { get; private set; }
        public DateTime EndDateBet { get; private set; }

        public int IdTypeBet { get; private set; }
        public Guid IdUser { get; private set; }
    }
}
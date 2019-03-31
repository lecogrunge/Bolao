using System;

namespace Bolao.Domain.Domains
{
    public sealed class Ticket
    {
        protected Ticket()
        {
        }

        public Guid TicketId { get; private set; }
    }
}
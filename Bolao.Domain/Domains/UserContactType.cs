using System;

namespace Bolao.Domain.Domains
{
    public sealed class UserContactType
    {
        public int UserContactTypeId { get; private set; }
        public Guid UserId { get; private set; }
        public int ContactTypeId { get; private set; }

        public User User { get; private set; }
        public ContactType ContactType { get; private set; }
    }
}
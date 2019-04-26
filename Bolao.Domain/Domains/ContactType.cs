using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
    public sealed class ContactType
	{
		public ContactType(string description)
		{
			this.Description = description;
		}

		public int ContactTypeId { get; private set; }
		public string Description { get; private set; }
        public ICollection<UserContactType> UsersContactTypes { get; private set; }
	}
}
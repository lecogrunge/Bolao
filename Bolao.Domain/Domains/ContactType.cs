using System.Collections;
using System.Collections.Generic;

namespace Bolao.Domain.Domains
{
	public sealed class ContactType
	{
		public ContactType(string description)
		{
			this.Description = description;
			this.Users = new HashSet<User>();
		}

		public int ContactTypeId { get; private set; }
		public string Description { get; private set; }
		public ICollection<User> Users { get; private set; }
	}
}
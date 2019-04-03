using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
	[Route("api/contact")]
	[ApiController]
	public class ContactController : BaseController
	{
		private readonly IContactService _contactService;

		public ContactController(IUnitOfWork unitOfWork, IContactService contactService) : base(unitOfWork)
		{
			_contactService = contactService;
		}

		[HttpPost]
		[Route("Contact")]
		public async Task<IActionResult> Contact(ContactRequest request)
		{
			ContactResponse response = _contactService.Contact(request);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}
	}
}
using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.Contact;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("api/contact")]
    [ApiController]
    [AllowAnonymous]
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IUnitOfWork unitOfWork, IContactService contactService) : base(unitOfWork)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route("contact")]
        [IgnoreAntiforgeryTokenAttribute]
        [AllowAnonymous]
        public IActionResult Contact([FromBody] ContactRequest request)
        {
            ContactResponse response = _contactService.Contact(request);

			if (response.IsValid())
				return Json("");

            return BadRequest(response.GetErrors());
        }
    }
}
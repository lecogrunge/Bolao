using Bolao.Api.Controllers.Base;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Contact;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Contact(ContactRequest request)
        {
            try
            {
                ContactResponse response = _contactService.Contact(request);

                if (response.IsValid())
                    return Json(true);

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
        }
    }
}
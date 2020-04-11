using Bolao.Api.Controllers.Base;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Contact;
using Bolao.Domain.Interfaces.Services;
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
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        /// <summary>
        /// Contact
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("contact")]
        [IgnoreAntiforgeryTokenAttribute]
        [AllowAnonymous]
        public IActionResult Contact(ContactRequest request)
        {
            try
            {
                ContactResponse response = contactService.Contact(request);

                if (response.IsValid())
                {
                    return Ok(response);
                }

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
        }
    }
}
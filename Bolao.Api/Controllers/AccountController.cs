using Bolao.Api.Controllers.Base;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    [AllowAnonymous]
    public sealed class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IUnitOfWork unitOfWork, IAccountService accountService) : base(unitOfWork)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(CreateAccountRequest signup)
        {
            try
            {
                CreateAccountResponse response = _accountService.CreateAccount(signup);

                if (response.IsValid())
                {
                    return await ResponseAsync(response);
                }

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromForm]LoginRequest auth)
        {
            try
            {
                LoginResponse response = _accountService.Login(auth);

                if (response.IsValid())
                {
                    return await ResponseAsync(response);
                }

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
        }

        [HttpGet]
        [Route("confirm-account")]
        public async Task<IActionResult> ConfirmAccount(Guid token)
        {
            try
            {
                ConfirmAccountResponse response = _accountService.ConfirmAccount(token);

                if (response.IsValid())
                {
                    return await ResponseAsync(response);
                }

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
        }

        [HttpGet]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                ForgotPasswordResponse response = _accountService.ForgotPassword(email);

                if (response.IsValid())
                {
                    return await ResponseAsync(response);
                }

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
        }

        [HttpGet]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                ChangePasswordResponse response = _accountService.ChangePassword(request);

                if (response.IsValid())
                {
                    return await ResponseAsync(response);
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
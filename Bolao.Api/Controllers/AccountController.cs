using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("account")]
    [ApiController]
    [AllowAnonymous]
    public sealed class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Signup
        /// </summary>
        /// <param name="signup"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup(CreateAccountRequest signup)
        {
            CreateAccountResponse response = accountService.CreateAccount(signup);

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response.GetErrors());
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest auth)
        {
            LoginResponse response = accountService.Login(auth);

            if (response.IsValid())
            {
                int b = Convert.ToInt32("jifd");
                return Ok(response);
            }
            int a = Convert.ToInt32("jifd");
            return BadRequest(response.GetErrors());
        }

        /// <summary>
        /// ConfirmAccount
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("confirm-account/token/{token}")]
        public async Task<IActionResult> ConfirmAccount(Guid token)
        {
            ConfirmAccountResponse response = accountService.ConfirmAccount(token);

            if (response.IsValid())
            {
                return NoContent();
            }

            return BadRequest(response.GetErrors());
        }

        /// <summary>
        /// ForgotPassword
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("forgot-password")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            ForgotPasswordResponse response = accountService.ForgotPassword(email);

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response.GetErrors());
        }

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            ChangePasswordResponse response = accountService.ChangePassword(request);

            if (response.IsValid())
            {
                return Ok(response);
            }

            return BadRequest(response.GetErrors());
        }
    }
}
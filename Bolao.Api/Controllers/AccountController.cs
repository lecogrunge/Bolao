using Bolao.Api.Controllers.Base;
using Bolao.CrossCutting.Messages;
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
            try
            {
                CreateAccountResponse response = accountService.CreateAccount(signup);
                
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

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest auth)
        {
            try
            {
                LoginResponse response = accountService.Login(auth);

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

        /// <summary>
        /// ConfirmAccount
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("confirm-account/token/{token}")]
        public async Task<IActionResult> ConfirmAccount(Guid token)
        {
            try
            {
                ConfirmAccountResponse response = accountService.ConfirmAccount(token);

                if (response.IsValid())
                {
                    return NoContent();
                }

                return BadRequest(response.GetErrors());
            }
            catch (Exception)
            {
                return BadRequest(Msg.ErrorGeneric400);
            }
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
            try
            {
                ForgotPasswordResponse response = accountService.ForgotPassword(email);

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

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                ChangePasswordResponse response = accountService.ChangePassword(request);

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
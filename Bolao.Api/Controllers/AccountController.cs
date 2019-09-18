using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.Interfaces.UnitOfWork;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
	[Route("api/account")]
	[ApiController]
	[AllowAnonymous]
	public class AccountController : BaseController
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
			CreateAccountResponse response = _accountService.CreateAccount(signup);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromForm]LoginRequest auth)
		{
			LoginResponse response = _accountService.Login(auth);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpGet]
		[Route("confirm-account")]
		public async Task<IActionResult> ConfirmAccount(Guid token)
		{
			ConfirmAccountResponse response = _accountService.ConfirmAccount(token);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpGet]
		[Route("forgot-password")]
		public async Task<IActionResult> ForgotPassword(string email)
		{
			ForgotPasswordResponse response = _accountService.ForgotPassword(email);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpGet]
		[Route("change-password")]
		public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
		{
			ChangePasswordResponse response = _accountService.ChangePassword(request);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}
	}
}
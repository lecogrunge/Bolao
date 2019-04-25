using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : BaseController
	{
		private readonly IUserService _userService;

		public UserController(IUnitOfWork unitOfWork, IUserService userService) : base(unitOfWork)
		{
			_userService = userService;
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateUser(CreateUserRequest user)
		{
			CreateUserResponse response = _userService.CreateUser(user);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpPost]
		[Route("auth")]
		public async Task<IActionResult> AuthUser(AuthUserRequest auth)
		{
			AuthUserResponse response = _userService.AuthUser(auth);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpGet]
		[Route("confirm-user-created")]
		public async Task<IActionResult> ConfirmUserCreated(Guid token)
		{
			ConfirmUserCreatedResponse response = _userService.ConfirmUserCreated(token);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpGet]
		[Route("forgot-password")]
		public async Task<IActionResult> ForgotPassword(string email)
		{
			ForgotPasswordResponse response = _userService.ForgotPassword(email);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}

		[HttpGet]
		[Route("change-password")]
		public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
		{
			ChangePasswordResponse response = _userService.ChangePassword(request);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}
	}
}
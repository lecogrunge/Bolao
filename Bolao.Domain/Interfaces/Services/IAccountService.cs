using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services.Base;
using System;

namespace Bolao.Domain.Interfaces.Services
{
    public interface IAccountService : IServiceBase
    {
        CreateAccountResponse CreateAccount(CreateAccountRequest request);
		LoginResponse Login(LoginRequest request);
		ConfirmAccountResponse ConfirmAccount(Guid token);
		ForgotPasswordResponse ForgotPassword(string email);
		ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
	}
}
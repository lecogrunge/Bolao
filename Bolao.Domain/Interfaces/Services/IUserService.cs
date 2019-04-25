using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services.Base;
using System;

namespace Bolao.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase
    {
        CreateUserResponse CreateUser(CreateUserRequest request);
		AuthUserResponse AuthUser(AuthUserRequest request);
		ConfirmUserCreatedResponse ConfirmUserCreated(Guid token);
		ForgotPasswordResponse ForgotPassword(string email);
		ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
	}
}
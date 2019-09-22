using Bolao.CrossCutting.Common;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.ObjectValue;
using Bolao.Domain.ObjectValue.Validation;
using FluentValidation.Results;
using System;

namespace Bolao.Domain.Services
{
	public sealed class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
		private readonly IUserSecurityRepository _userSecurityRepository;
		private readonly IEmailService _emailService;
		
        public AccountService(IUserRepository userRepository, IUserSecurityRepository userSecurityRepository, IEmailService emailService)
        {
            this._userRepository = userRepository;
			this._userSecurityRepository = userSecurityRepository;
            this._emailService = emailService;
        }

		public LoginResponse Login(LoginRequest request)
		{
			LoginResponse response = new LoginResponse();

			// E-mail validation
			Email email = new Email(request.Email);
			EmailValidator emailValidator = new EmailValidator();
			ValidationResult emailResult = emailValidator.Validate(email);
			if (!emailResult.IsValid)
				response.AddErrorValidationResult(emailResult);

			// Verificar usuário existe
			User user = _userRepository.AuthUser(email.EmailAddress, request.Password.CryptPassword());
            if (user == null)
                response.AddError(new ErrorResponse(string.Empty, Msg.InvalidAuth)); 

            if (!response.IsValid())
                return response;

            response.IdUser = user.UserId;
			response.FirstName = user.FisrtName;

            return response;
		}

		public CreateAccountResponse CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse response = new CreateAccountResponse();

            // E-mail validation
            Email email = new Email(request.Email);
			EmailValidator emailValidator = new EmailValidator();
            ValidationResult emailResult = emailValidator.Validate(email);
            if (!emailResult.IsValid)
                response.AddErrorValidationResult(emailResult);

            // User validation
            User user = new User(request.FisrtName, request.LastName, email, request.Password);
			UserValidator userValidator = new UserValidator();
            ValidationResult userResult = userValidator.Validate(user);
            if (!userResult.IsValid)
                response.AddErrorValidationResult(userResult);
            
            if (_userRepository.IsEmailExist(user.Email.EmailAddress))
                response.AddError(new ErrorResponse("Email", Msg.EmailExists));

            if(!response.IsValid())
                return response;

            // Persistence 
            user.CryptPassword(user.Password);
            _userRepository.Create(user);

			// Send mail
			_emailService.SendEmailNewUser(user.Email.EmailAddress, user.UserSecurity.TokenCreateConfirmed, user.FisrtName);

			response.IdUser = user.UserId;
            return response;
        }

		public ConfirmAccountResponse ConfirmAccount(Guid token)
		{
			ConfirmAccountResponse response = new ConfirmAccountResponse();

			User user = _userRepository.GetUserByTokenConfirmation(token);
            if (user != null)
            {
                user.ActiveUser();
                _userRepository.Update(user);
            }
            else
                response.AddError(new ErrorResponse(string.Empty, Msg.InvalidConfirmToken));

			return response;
		}

		public ForgotPasswordResponse ForgotPassword(string emailUser)
		{
			ForgotPasswordResponse response = new ForgotPasswordResponse();
			
			// E-mail validation
			Email email = new Email(emailUser);
			EmailValidator emailValidator = new EmailValidator();
			ValidationResult emailResult = emailValidator.Validate(email);
			if (!emailResult.IsValid)
			{
				response.AddErrorValidationResult(emailResult);
				return response;
			}

			// Persistence
			UserSecurity security = _userSecurityRepository.GetByEmail(email.EmailAddress);
			security.GenerateTokenForgotPassword();
			_userSecurityRepository.Update(security);

			// Send mail
			_emailService.SendEmailForgotPassword(email.EmailAddress, security.TokenForgotPassword.Value);

			return response;
		}

		public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
		{
			ChangePasswordResponse response = new ChangePasswordResponse();

			// Validation
			if (!request.NewPassword.Equals(request.NewPasswordConfirm))
			{
				response.AddError(new ErrorResponse("Password", Msg.PasswordNotTheSame));
				return response;
			}

			User user = _userRepository.GetUserByTokenForgotPassword(request.Token);
			if (user == null)
			{
				response.AddError(new ErrorResponse(string.Empty, Msg.InvalidForgotPasswordToken));
				return response;
			}

			user.CryptPassword(request.NewPassword);
			_userRepository.Update(user);

			return response;
		}
	}
}
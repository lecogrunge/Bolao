using Bolao.CrossCutting.Common;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base.Error;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.HandleErrror;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.Interfaces.UnitOfWork;
using Bolao.Domain.ObjectValue;
using Bolao.Domain.ObjectValue.Validation;
using FluentValidation.Results;
using System;

namespace Bolao.Domain.Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailService emailService;
        private readonly IHandlerError handlerError;

        public AccountService(IUnitOfWork unitOfWork, IEmailService emailService, IHandlerError handlerError)
        {
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
            this.handlerError = handlerError;
        }

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            // E-mail validation
            Email email = new Email(request.Email);
            EmailValidator emailValidator = new EmailValidator();
            ValidationResult emailResult = emailValidator.Validate(email);
            if (!emailResult.IsValid)
            {
                response.AddErrorValidationResult(emailResult);
                return response;
            }

            // Verify if user exists
            User user = unitOfWork.UserRepository.AuthUser(email.EmailAddress, request.Password.CryptPassword());
            if (user == null)
            {
                response.AddError(new ErrorResponse(string.Empty, Msg.InvalidAuth));
                return response;
            }

            // Verify if user is active
            bool userActive = unitOfWork.UserRepository.VerifyUserIsActiveByEmail(request.Email);
            if (userActive == false)
            {
                response.AddError(new ErrorResponse(string.Empty, Msg.AccountInactive));
                return response;
            }

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
            {
                response.AddErrorValidationResult(emailResult);
                return response;
            }

            if (unitOfWork.UserRepository.IsEmailExists(request.Email))
            {
                response.AddError(new ErrorResponse("Email", Msg.EmailExists));
                return response;
            }

            // User validation
            User user = new User(request.FisrtName, request.LastName, email, request.Password);
            UserValidator userValidator = new UserValidator();
            ValidationResult userResult = userValidator.Validate(user);
            if (!userResult.IsValid)
            {
                response.AddErrorValidationResult(userResult);
                return response;
            }

            // Crypt
            user.CryptPassword(user.Password);

            // Persistence
            unitOfWork.UserRepository.Create(user);
            unitOfWork.Save();

            // Send mail
            emailService.SendEmailNewUser(user.Email.EmailAddress, user.UserSecurity.TokenCreateConfirmed, user.FisrtName);

            response.IdUser = user.UserId;
            return response;
        }

        public ConfirmAccountResponse ConfirmAccount(Guid token)
        {
            ConfirmAccountResponse response = new ConfirmAccountResponse();

            User user = unitOfWork.UserRepository.GetUserByTokenConfirmation(token);
            if (user != null)
            {
                user.ActiveUser();

                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            else
            {
                response.AddError(new ErrorResponse(string.Empty, Msg.InvalidConfirmToken));
            }

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
            UserSecurity security = unitOfWork.UserSecurityRepository.GetByEmail(email.EmailAddress);
            security.GenerateTokenForgotPassword();
            unitOfWork.UserSecurityRepository.Update(security);

            // Send mail
            emailService.SendEmailForgotPassword(email.EmailAddress, security.TokenForgotPassword.Value);

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

            User user = unitOfWork.UserRepository.GetUserByTokenForgotPassword(request.Token);
            if (user == null)
            {
                response.AddError(new ErrorResponse(string.Empty, Msg.InvalidForgotPasswordToken));
                return response;
            }

            user.CryptPassword(request.NewPassword);
            unitOfWork.UserRepository.Update(user);

            return response;
        }
    }
}
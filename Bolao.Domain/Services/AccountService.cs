using Bolao.CrossCutting.Common;
using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base.Error;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.Interfaces.UnitOfWork;
using Bolao.Domain.ObjectValue;
using Bolao.Domain.ObjectValue.Validation;
using FluentValidation.Results;
using System;
using System.Reflection;

namespace Bolao.Domain.Services
{
    public sealed class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailService emailService;

        public AccountService(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
        }

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();

            try
            {
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
                User user = this.unitOfWork.UserRepository.AuthUser(email.EmailAddress, request.Password.CryptPassword());
                if (user == null)
                {
                    response.AddError(new ErrorResponse(string.Empty, Msg.InvalidAuth));
                    return response;
                }

                // Verify if user is active
                this.unitOfWork.UserRepository.VerifyUserIsActiveByEmail(request.Email);

                response.IdUser = user.UserId;
                response.FirstName = user.FisrtName;

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public CreateAccountResponse CreateAccount(CreateAccountRequest request)
        {
            CreateAccountResponse response = new CreateAccountResponse();

            try
            {
                // E-mail validation
                Email email = new Email(request.Email);
                EmailValidator emailValidator = new EmailValidator();
                ValidationResult emailResult = emailValidator.Validate(email);
                if (!emailResult.IsValid)
                {
                    response.AddErrorValidationResult(emailResult);
                    return response;
                }

                if (this.unitOfWork.UserRepository.IsEmailExists(request.Email))
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
                this.unitOfWork.OpenTransaction();
                this.unitOfWork.UserRepository.Create(user);
                this.unitOfWork.CommitTransaction();
                this.unitOfWork.Save();

                // Send mail
                this.emailService.SendEmailNewUser(user.Email.EmailAddress, user.UserSecurity.TokenCreateConfirmed, user.FisrtName);

                response.IdUser = user.UserId;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public ConfirmAccountResponse ConfirmAccount(Guid token)
        {
            ConfirmAccountResponse response = new ConfirmAccountResponse();

            try
            {
                User user = this.unitOfWork.UserRepository.GetUserByTokenConfirmation(token);
                if (user != null)
                {
                    user.ActiveUser();
                    this.unitOfWork.UserRepository.Update(user);
                }
                else
                {
                    response.AddError(new ErrorResponse(string.Empty, Msg.InvalidConfirmToken));
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public ForgotPasswordResponse ForgotPassword(string emailUser)
        {
            ForgotPasswordResponse response = new ForgotPasswordResponse();

            try
            {
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
                UserSecurity security = this.unitOfWork.UserSecurityRepository.GetByEmail(email.EmailAddress);
                security.GenerateTokenForgotPassword();
                this.unitOfWork.UserSecurityRepository.Update(security);

                // Send mail
                emailService.SendEmailForgotPassword(email.EmailAddress, security.TokenForgotPassword.Value);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public ChangePasswordResponse ChangePassword(ChangePasswordRequest request)
        {
            ChangePasswordResponse response = new ChangePasswordResponse();

            try
            {
                // Validation
                if (!request.NewPassword.Equals(request.NewPasswordConfirm))
                {
                    response.AddError(new ErrorResponse("Password", Msg.PasswordNotTheSame));
                    return response;
                }

                User user = this.unitOfWork.UserRepository.GetUserByTokenForgotPassword(request.Token);
                if (user == null)
                {
                    response.AddError(new ErrorResponse(string.Empty, Msg.InvalidForgotPasswordToken));
                    return response;
                }

                user.CryptPassword(request.NewPassword);
                this.unitOfWork.UserRepository.Update(user);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }
    }
}
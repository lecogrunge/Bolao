using Bolao.Domain.Arguments.User;
using Bolao.Domain.Domains;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using Bolao.Domain.ObjectValue;
using FluentValidation.Results;

namespace Bolao.Domain.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            this._userRepository = userRepository;
            this._emailService = emailService;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            CreateUserResponse response = new CreateUserResponse();

            // E-mail validation
            Email email = new Email(request.Email);
            ValidationResult emailValidation = email.Validate(email);
            if (!emailValidation.IsValid)
                response.AddError(emailValidation);

            // User validation
            User user = new User(request.FisrtName, request.LastName, email, request.Password);
            ValidationResult userValidation = user.Validate(user);
            if (!userValidation.IsValid)
                response.AddError(userValidation);

            if(!response.IsValid())
                return response;

            // Persistence
            _userRepository.Create(user);

            // Other Services
            //_emailService.SendEmail(user.Email.EmailAddress, "my title", "my content");

            response.IdUser = user.IdUser;
            return response;
        }
    }
}
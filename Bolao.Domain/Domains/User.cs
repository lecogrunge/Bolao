using Bolao.Domain.ObjectValue;
using FluentValidation;
using System;

namespace Bolao.Domain.Domains
{
    public sealed class User : AbstractValidator<User>
    {
        protected User() { }

        public User(string fisrtName, string lastName, Email email, string password)
        {
            IdUser = Guid.NewGuid();
            FisrtName = fisrtName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreateDate = DateTime.Now;
            Active = false;

            RuleFor(x => x.FisrtName).NotEmpty().WithMessage("Primeiro Nome obrigatório.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Último Nome obrigatório.");
        }

        public Guid IdUser { get; private set; }
        public string FisrtName { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool Active { get; private set; }
    }
}
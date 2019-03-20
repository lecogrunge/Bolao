using FluentValidation;

namespace Bolao.Domain.ObjectValue
{
    public sealed class Email : AbstractValidator<Email>
    {
        protected Email() { }

        public Email(string address)
        {
            EmailAddress = address;

            RuleFor(x => x.EmailAddress).Cascade(CascadeMode.StopOnFirstFailure);
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("E-mail obrigatório.");
            RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("E-mail inválido.");
        }

        public string EmailAddress { get; private set; }
    }
}
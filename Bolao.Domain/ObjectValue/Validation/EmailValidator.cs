using Bolao.CrossCutting.Messages;
using FluentValidation;

namespace Bolao.Domain.ObjectValue.Validation
{
    public sealed class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.EmailAddress).Cascade(CascadeMode.StopOnFirstFailure);
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage(string.Format(Msg.RequiredFieldX, "E-mail."));
            RuleFor(x => x.EmailAddress).EmailAddress().WithMessage(s => string.Format(Msg.InvalidEmail, s.EmailAddress));
        }
    }
}
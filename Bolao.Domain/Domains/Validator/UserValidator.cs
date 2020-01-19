using Bolao.CrossCutting.Messages;
using FluentValidation;

namespace Bolao.Domain.Domains.Validator
{
    public sealed class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FisrtName).NotEmpty().WithMessage(string.Format(Msg.RequiredFieldX, "Nome"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(string.Format(Msg.RequiredFieldX, "Sobrenome"));
            RuleFor(x => x.Password).Cascade(CascadeMode.StopOnFirstFailure)
                                    .NotEmpty().WithMessage(string.Format(Msg.RequiredFieldX, "Senha"))
                                    .MinimumLength(8).WithMessage(string.Format(Msg.RangeLength, "Senha", "8", "16"))
                                    .MaximumLength(16).WithMessage(string.Format(Msg.RangeLength, "Senha", "8", "16"));
        }
    }
}
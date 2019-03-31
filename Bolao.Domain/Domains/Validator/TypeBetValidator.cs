using Bolao.CrossCutting.Messages;
using FluentValidation;

namespace Bolao.Domain.Domains.Validator
{
	public sealed class TypeBetValidator : AbstractValidator<TypeBet>
	{
		public TypeBetValidator()
		{
			RuleFor(s => s.Description).NotEmpty().WithMessage(string.Format(Msg.RequiredFieldX, "Descrição"));
		}
	}
}
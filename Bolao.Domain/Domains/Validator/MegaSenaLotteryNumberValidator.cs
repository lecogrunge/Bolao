using Bolao.CrossCutting.Messages;
using FluentValidation;

namespace Bolao.Domain.Domains.Validator
{
	public sealed class MegaSenaLotteryNumberValidator : AbstractValidator<MegaSenaLotteryNumber>
	{
		public MegaSenaLotteryNumberValidator()
		{
			RuleFor(x => x.Number).NotEmpty().WithMessage(string.Format(Msg.InvalidField, "Número"));
		}
	}
}
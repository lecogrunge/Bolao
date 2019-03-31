using Bolao.CrossCutting.Messages;
using FluentValidation;

namespace Bolao.Domain.Domains.Validator
{
	public sealed class LotteryNumberResultValidator : AbstractValidator<LotteryNumberResult>
	{
		public LotteryNumberResultValidator()
		{
			RuleFor(x => x.Number).NotEmpty().WithMessage(string.Format(Msg.InvalidField, "Número"));
		}
	}
}
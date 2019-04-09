using Bolao.CrossCutting.Messages;
using FluentValidation;

namespace Bolao.Domain.Domains.Validator
{
	public sealed class LotteryNumberResultValidator : AbstractValidator<LotteryNumberResult>
	{
		public LotteryNumberResultValidator()
		{
			RuleFor(x => x.Number).Cascade(CascadeMode.StopOnFirstFailure)
								  .NotEmpty().WithMessage(string.Format(Msg.InvalidField, "Número"))
								  .Must(ValidarNumero).WithMessage(Msg.InvalidNumberLottery);
		}

		private bool ValidarNumero(string number)
		{
			return number.Length == 2;
		}
	}
}
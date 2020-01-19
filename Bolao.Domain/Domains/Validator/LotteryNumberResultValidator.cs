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
                                  .Must(ValidateNumberSize).WithMessage(Msg.InvalidNumberLottery)
                                  .Must(ValidateIsNumber).WithMessage(Msg.InvalidNumberLottery);
        }

        private bool ValidateNumberSize(string number)
        {
            return number.Length == 2;
        }

        // TODO
        private bool ValidateIsNumber(string number)
        {
            return false;
        }
    }
}
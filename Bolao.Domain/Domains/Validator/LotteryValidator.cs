using Bolao.CrossCutting.Messages;
using Bolao.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains.Validator
{
	public sealed class LotteryValidator : AbstractValidator<Lottery>
	{
		public LotteryValidator()
		{
			RuleFor(x => x.Price).Must(ValidatePrice).WithMessage(string.Format(Msg.InvalidField, "Valor da aposta"));
			RuleFor(x => x.StartDateBet).Must(ValidateStartDateBet).WithMessage(string.Format(Msg.InvalidField, "Data incial das apostas"));
			RuleFor(x => x.EndDateBet).Must((arg, ValidateEndDateBet) => this.ValidateEndDateBet(arg.StartDateBet, arg.EndDateBet)).WithMessage(string.Format(Msg.InvalidField, "Data final das apostas"));
            RuleFor(x => x.ListNumbersResult).Must((arg, ValidateLimitNumbers) => this.ValidateLimitNumbers(arg.ListNumbersResult, (int)arg.TypeBetId)).WithMessage(Msg.InvalidLimitNumbers);
		}

		private bool ValidatePrice(decimal price)
		{
			return price > 0;
		}

		private bool ValidateStartDateBet(DateTime startDate)
		{
			return startDate.Date > DateTime.Now.Date;
		}

		private bool ValidateEndDateBet(DateTime startDate, DateTime endDate)
		{
			return endDate.Date > startDate.Date;
		}

        private bool ValidateLimitNumbers(ICollection<LotteryNumberResult> numbers, int typeBetId)
        {
            if((int)EnumTypeBet.Sena15Numbers == typeBetId)
                return numbers.Count == 6;

            return false;
        }
    }
}
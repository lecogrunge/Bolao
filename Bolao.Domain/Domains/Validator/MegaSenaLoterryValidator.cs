using Bolao.CrossCutting.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Bolao.Domain.Domains.Validator
{
	public sealed class MegaSenaLoterryValidator : AbstractValidator<MegaSenaLottery>
	{
		public MegaSenaLoterryValidator()
		{
			RuleFor(x => x.LoterryDate).Must(ValidateLoterryDate).WithMessage(string.Format(Msg.InvalidField, "Data sorteio da MegaSena"));
			RuleFor(x => x.ListNumbers).Must(ValidateLimitNumbers).WithMessage(Msg.InvalidLimitNumbers);
		}

		private bool ValidateLimitNumbers(ICollection<MegaSenaLotteryNumber> numbers)
		{
			return numbers.Count == 6;
		}

		private bool ValidateLoterryDate(DateTime startDate)
		{
			return startDate.Date > DateTime.Now.Date;
		}
	}
}
using Bolao.CrossCutting.Messages;
using FluentValidation;
using System;

namespace Bolao.Domain.Domains.Validator
{
	public sealed class TicketValidator : AbstractValidator<Ticket>
	{
		public TicketValidator()
		{
			RuleFor(x => x.Price).Must(ValidatePrice).WithMessage(string.Format(Msg.InvalidField, "Valor da aposta"));
			RuleFor(x => x.StartDateBet).Must(ValidateStartDateBet).WithMessage(string.Format(Msg.InvalidField, "Data incial das apostas"));
			RuleFor(x => x.EndDateBet).Must((arg, ValidateEndDateBet) => this.ValidateEndDateBet(arg.StartDateBet, arg.EndDateBet)).WithMessage(string.Format(Msg.InvalidField, "Data final das apostas"));
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
	}
}
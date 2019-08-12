using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base;
using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using FluentValidation.Results;
using System.Linq;

namespace Bolao.Domain.Services
{
    public sealed class LotteryService : ILotteryService
	{
		private readonly ILotteryReposiory _lotteryRepository;

		public LotteryService(ILotteryReposiory lotteryRepository)
		{
			_lotteryRepository = lotteryRepository;
		}

		public CreateLotteryResponse CreateLottery(CreateLotteryRequest request)
		{
			CreateLotteryResponse response = new CreateLotteryResponse();

			// Validate Lottery
			Lottery lottery = new Lottery(request.Price, request.StartDateBet, request.EndDateBet, request.LotteryDateBet, (int)request.TypeBetId);
			LotteryValidator ticketValidator = new LotteryValidator();
			ValidationResult ticketResult = ticketValidator.Validate(lottery);
			if (!ticketResult.IsValid)
			{
				response.AddErrorValidationResult(ticketResult);
				return response;
			}

			_lotteryRepository.Create(lottery);

			return response;
		}

		public NumberLotteryResponse InsertNumbersLotteryResult(NumberLotteryRequest request)
		{
			NumberLotteryResponse response = new NumberLotteryResponse();
			Lottery lottery =  _lotteryRepository.FindLottery(request.LotteryId);

            if (lottery == null)
            {
                response.AddError(new ErrorResponseBase(string.Empty, Msg.LotteryNotFound));
                return response;
            }

            if (request.Numbers.Count() != lottery.TypeBet.CountNumberResult)
            {
                response.AddError(new ErrorResponseBase("Number", Msg.LimiteLotteryResultInvalid));
                return response;
            }

			// Binding numbers
			foreach (string item in request.Numbers)
			{
				LotteryNumberResult number = new LotteryNumberResult(item, request.LotteryId);
				LotteryNumberResultValidator numberValidator = new LotteryNumberResultValidator();
				ValidationResult numberResult = numberValidator.Validate(number);
				if (!numberResult.IsValid)
				{
					response.AddErrorValidationResult(numberResult);
					return response;
				}

                if (lottery.ListNumbersResult.Any(s => s.Number.Contains(item)))
                {
                    response.AddError(new ErrorResponseBase("Number", Msg.NumberBetDuplicated));
                    return response;
                }

				lottery.SetNumberInListLottery(number);
			}

			_lotteryRepository.Update(lottery);

			return response;
		}

        public ListLotteryResponse ListLottery(bool active)
		{
			ListLotteryResponse response = new ListLotteryResponse();

			response.ListLotteries = _lotteryRepository.ListLotteries(active);
			return response;
		}
	}
}
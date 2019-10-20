using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base;
using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Reflection;

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

            try
            {
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
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

		public NumberLotteryResponse InsertNumbersLotteryResult(NumberLotteryRequest request)
		{
			NumberLotteryResponse response = new NumberLotteryResponse();

            try
            {
                Lottery lottery = _lotteryRepository.FindLottery(request.LotteryId);

                if (lottery == null)
                {
                    response.AddError(new ErrorResponse(string.Empty, Msg.LotteryNotFound));
                    return response;
                }

                if (request.Numbers.Count() != lottery.TypeBet.CountNumberResult)
                {
                    response.AddError(new ErrorResponse("Number", Msg.LimiteLotteryResultInvalid));
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
                        response.AddError(new ErrorResponse("Number", Msg.NumberBetDuplicated));
                        return response;
                    }

                    lottery.SetNumberInListLottery(number);
                }

                _lotteryRepository.Update(lottery);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }

        public ListLotteryResponse ListLottery(bool active)
		{
			ListLotteryResponse response = new ListLotteryResponse();

            try
            {
                response.ListLotteries = _lotteryRepository.ListLotteries(active);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
        }
	}
}
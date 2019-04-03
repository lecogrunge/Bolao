using Bolao.Domain.Arguments.Lottery;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using FluentValidation.Results;

namespace Bolao.Domain.Services
{
    public sealed class LotteryService : ILotteryService
	{
		private readonly ILotteryReposiory _ticketRepository;

		public LotteryService(ILotteryReposiory ticketRepository)
		{
			_ticketRepository = ticketRepository;
		}

		public CreateLotteryResponse CreateLottery(CreateLotteryRequest request)
		{
			CreateLotteryResponse response = new CreateLotteryResponse();

			// Validate Lottery
			Lottery ticket = new Lottery(request.Price, request.StartDateBet, request.EndDateBet, request.LotteryDateBet, (int)request.TypeBetId);
			LotteryValidator ticketValidator = new LotteryValidator();
			ValidationResult ticketResult = ticketValidator.Validate(ticket);
			if (!ticketResult.IsValid)
				response.AddErrorValidationResult(ticketResult);

			return response;
		}

        public void InsertResult()
        {

            // Binding numbers
            //foreach (string item in request.BetNumbers)
            //    megaSena.AddNumber(new LotteryNumberResult(item, megaSena.MegaSenaLoterryId));

            //// Validate
            //MegaSenaLoterryValidator megaSenaValidator = new MegaSenaLoterryValidator();
            //ValidationResult megaSenaResult = megaSenaValidator.Validate(megaSena);
            //if (megaSenaResult.IsValid)
            //    response.AddErrorValidationResult(megaSenaResult);
        }

        public ListLotteryResponse ListLottery(ListLotteryRequest request)
		{
			ListLotteryResponse response = new ListLotteryResponse();

			response.ListLotteries = _ticketRepository.ListLotteries(request);
			return response;
		}
	}
}
using Bolao.Domain.Arguments.MegaSenaLoterry;
using Bolao.Domain.Domains;
using Bolao.Domain.Domains.Validator;
using Bolao.Domain.Interfaces.Repositories;
using Bolao.Domain.Interfaces.Services;
using FluentValidation.Results;

namespace Bolao.Domain.Services
{
	public sealed class MegaSenaService : IMegaSenaService
    {
        private readonly IMegaSenaRepository _megaSenaRepository;

        public MegaSenaService(IMegaSenaRepository megaSenaRepository)
        {
            this._megaSenaRepository = megaSenaRepository;
        }

		public CreateMegaSenaResponse CreateMegaSena(CreateMegaSenaRequest request)
		{
			CreateMegaSenaResponse response = new CreateMegaSenaResponse();

			MegaSenaLottery megaSena = new MegaSenaLottery(request.LoterryDate);

			// Binding numbers
			foreach(string item in request.BetNumbers)
				megaSena.AddNumber(new MegaSenaLotteryNumber(item, megaSena.IdMegaSenaLoterry));

			// Validate
			MegaSenaLoterryValidator megaSenaValidator = new MegaSenaLoterryValidator();
			ValidationResult megaSenaResult = megaSenaValidator.Validate(megaSena);
			if (megaSenaResult.IsValid)
				response.AddError(megaSenaResult);

			if (!response.IsValid())
				return response;

			// Persistence
			_megaSenaRepository.Create(megaSena);

			return response;
		}
	}
}
using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.MegaSenaLoterry;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
	[Route("api/MegaSena")]
	[ApiController]
	public class MegaSenaController : BaseController
	{
		private readonly IMegaSenaService _megaSenaService;

		public MegaSenaController(IUnitOfWork unitOfWork, IMegaSenaService megaSenaService) : base(unitOfWork)
		{
			_megaSenaService = megaSenaService;
		}

		[HttpPost]
		public async Task<IActionResult> PostMegaSena(CreateMegaSenaRequest request)
		{
			CreateMegaSenaResponse response = _megaSenaService.CreateMegaSena(request);

			if (response.IsValid())
				return await ResponseAsync(response);

			return BadRequest(response.GetErrors());
		}
	}
}
using Bolao.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers.Base
{
    public class BaseController : Controller
	{
		protected readonly IUnitOfWork _unitOfWork;

		public BaseController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		public async Task<IActionResult> ResponseAsync(object result)
		{
			try
			{
				_unitOfWork.CommitTransaction();
				return Ok(result);
			}
			catch (Exception ex)
			{
                throw new Exception(MethodBase.GetCurrentMethod().ToString(), ex);
            }
		}
	}
}
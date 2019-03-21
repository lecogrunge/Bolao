using Bolao.Domain.Arguments.Base;
using Bolao.Domain.Interfaces.Arguments;
using Bolao.Domain.Messages;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
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

		public async Task<IActionResult> ResponseAsync(object result, bool isValid, IList<ErrorResponseBase> errorList)
		{
			if (!isValid)
			{
				try
				{
					_unitOfWork.Commit();
					return Ok(result);
				}
				catch (Exception ex)
				{
					return BadRequest(Msg.ErrorGeneric400);
				}
			}
			else
				return BadRequest(errorList);
		}

		public async Task<IActionResult> ResponseExceptionAsync(Exception ex)
		{
			return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
		}
	}
}
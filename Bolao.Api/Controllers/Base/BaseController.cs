using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace Bolao.Api.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
		private readonly IResponseBase _responseBase;

        public BaseController(IUnitOfWork unitOfWork, IResponseBase responseBase)
        {
            _unitOfWork = unitOfWork;
			_responseBase = responseBase;
        }
    }
}
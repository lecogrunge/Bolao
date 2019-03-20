using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace Bolao.Api.Controllers.Base
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
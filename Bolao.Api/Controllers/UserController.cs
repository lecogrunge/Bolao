using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
	[Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUnitOfWork unitOfWork, IUserService userService) : base(unitOfWork)
        {
            _userService = userService;            
        }
        
        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserRequest user)
        {
            CreateUserResponse response = _userService.CreateUser(user);
			return await ResponseAsync(response, response.IsValid(), response.GetErrors());
		}

		[HttpPost]
		public async Task<IActionResult> AuthUser(AuthUserRequest auth)
		{
			AuthUserResponse response = _userService.AuthUser(auth);
			return await ResponseAsync(response, response.IsValid(), response.GetErrors());
		}
	}
}
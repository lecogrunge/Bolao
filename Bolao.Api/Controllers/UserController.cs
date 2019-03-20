using Bolao.Api.Controllers.Base;
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services;
using Bolao.Infra.Transaction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bolao.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUnitOfWork unityOfWork, IUserService userService) : base(unityOfWork)
        {
            _userService = userService;            
        }
        
        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserRequest user)
        {
            CreateUserResponse response = _userService.CreateUser(user);

            if (response.IsValid())
            {
                try
                {
                    _unitOfWork.Commit();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
                }
            }

            return BadRequest(response.GetErrors());
        }
    }
}
using Bolao.Domain.Arguments.User;
using Bolao.Domain.Interfaces.Services.Base;

namespace Bolao.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase
    {
        //IEnumerable<ListarJogadorResponse> ListarJogador();
        CreateUserResponse CreateUser(CreateUserRequest request);
        //AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request);
        //AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);
        //ResponseBase ExcluirJogador(Guid id);
    }
}
namespace Bolao.Domain.Interfaces.HandleErrror
{
    public interface IHandlerError
    {
        void AddError(string mensagem);

        string GetError();
    }
}
namespace Bolao.Domain.Interfaces.HandleErrror
{
    public interface IHandlerError
    {
        void AddErrorMessage(string mensagem);

        string GetErrorMessage();
    }
}
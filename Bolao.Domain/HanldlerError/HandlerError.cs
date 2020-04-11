using Bolao.Domain.Interfaces.HandleErrror;
using System.Text;

namespace Bolao.Domain.HanldlerError
{
    public sealed class HandlerError : IHandlerError
    {
        private StringBuilder stb;

        public HandlerError()
        {
            this.stb = new StringBuilder();
        }

        public void AddError(string mensagem)
        {
            this.stb.AppendLine(mensagem);
        }

        public string GetError()
        {
            return this.stb.ToString();
        }
    }
}

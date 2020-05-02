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

        public void AddErrorMessage(string message)
        {
            this.stb.AppendLine(message);
        }

        public string GetErrorMessage()
        {
            return this.stb.ToString();
        }
    }
}

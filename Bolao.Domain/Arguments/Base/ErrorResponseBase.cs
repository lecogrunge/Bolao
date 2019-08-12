namespace Bolao.Domain.Arguments.Base
{
    public sealed class ErrorResponseBase
    {
        public string Property { get; set; }
        public string Message { get; set; }

        public ErrorResponseBase(string property, string message)
        {
            this.Property = property;
            this.Message = message;
        }
    }
}
namespace Bolao.Domain.Arguments.Base.Error
{
    public sealed class ErrorResponse
    {
        public string Property { get; private set; }
        public string Message { get; private set; }

        public ErrorResponse(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}
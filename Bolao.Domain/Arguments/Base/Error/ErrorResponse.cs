namespace Bolao.Domain.Arguments.Base.Error
{
    public sealed class ErrorResponse
    {
        public string Property { get; set; }
        public string Message { get; set; }

        public ErrorResponse(string property, string message)
        {
            this.Property = property;
            this.Message = message;
        }
    }
}
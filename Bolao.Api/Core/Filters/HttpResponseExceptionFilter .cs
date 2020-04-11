using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base.Error;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Bolao.Api.Core.Compression
{
    public sealed class HttpResponseExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = context.Exception.ToString();
            var exceptionType = context.Exception.GetType();

            ErrorResponse error = new ErrorResponse("400", Msg.ErrorGeneric400);

            context.ExceptionHandled = true;
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ContentType = "application/json";
            var err = message + " " + context.Exception.StackTrace;
        }
    }
}
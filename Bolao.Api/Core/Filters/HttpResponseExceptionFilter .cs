using Bolao.CrossCutting.Messages;
using Bolao.Domain.Arguments.Base.Error;
using Bolao.Domain.Interfaces.HandleErrror;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Bolao.Api.Core.Compression
{
    public sealed class HttpResponseExceptionFilter : IExceptionFilter
    {
        private readonly IHandlerError handlerError;

        public HttpResponseExceptionFilter(IHandlerError handlerError)
        {
            this.handlerError = handlerError;
        }

        public void OnException(ExceptionContext context)
        {
            String message = context.Exception.ToString();
            Type exceptionType = context.Exception.GetType();

            ErrorResponse error = new ErrorResponse("400", Msg.ErrorGeneric400);

            context.ExceptionHandled = true;
            context.Result = new BadRequestObjectResult(error);
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ContentType = "application/json";
        }
    }
}
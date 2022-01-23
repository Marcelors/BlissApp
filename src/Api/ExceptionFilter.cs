using System.Net;
using Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var exceptionMessage = context.Exception.Message;

            var problemDetails = new ProblemDetails
            {
                Title = Resource.InternalServerErrorTryAgainLater,
                Detail = exceptionMessage
            };

            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/problem+json";

            context.Result = new ObjectResult(problemDetails);
        }
    }
}

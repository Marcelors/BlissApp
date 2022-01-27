using System.Net;
using Application.Shared;
using Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode statusCode;
            var exceptionMessage = context.Exception.Message;
            ProblemDetails problemDetails;

            switch (context.Exception)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problemDetails = new ProblemDetails
                    {
                        Title = Resource.InternalServerErrorTryAgainLater,
                        Detail = exceptionMessage
                    };
                    break;

                case BusinessException:
                    statusCode = HttpStatusCode.UnprocessableEntity;
                    problemDetails = new ProblemDetails
                    {
                        Title = Resource.InternalServerErrorTryAgainLater,
                        Detail = exceptionMessage
                    };
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    problemDetails = new ProblemDetails
                    {
                        Title = Resource.InternalServerErrorTryAgainLater,
                        Detail = exceptionMessage
                    };
                    break;
            }

            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/problem+json";

            context.Result = new ObjectResult(problemDetails);
        }
    }
}

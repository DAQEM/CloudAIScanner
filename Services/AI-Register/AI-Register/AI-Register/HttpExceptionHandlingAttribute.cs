using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AIRegister
{
    public class HttpExceptionHandlingAttribute : ExceptionFilterAttribute
    {
      

     

        public override void OnException(ExceptionContext context)
        {

            if (!context.ExceptionHandled)
            {
                var exception = context.Exception;
                int statusCode;

                switch (true)
                {
                    case bool when exception is UnauthorizedAccessException:
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        break;


                    case bool when exception is InvalidOperationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;


                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                SetHttpException(context, statusCode);
            }
        }

        private static void SetHttpException(ExceptionContext context, int statusCode)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}

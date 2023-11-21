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
                Exception exception = context.Exception;
                HttpStatusCode statusCode;

                switch (true)
                {
                    case bool when exception is UnauthorizedAccessException:
                        statusCode = HttpStatusCode.Unauthorized;
                        break;


                    case bool when exception is InvalidOperationException:
                        statusCode = HttpStatusCode.BadRequest;
                        break;


                    default:
                        statusCode = HttpStatusCode.InternalServerError;
                        break;
                }

                SetHttpException(context, statusCode);
            }
        }

        private static void SetHttpException(ExceptionContext context, HttpStatusCode statusCode)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)statusCode;
            Console.Write(context.Exception.StackTrace);
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
            });
        }
    }
}

using Forum.Common.Exeptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Infrastructure.Attributes
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiException apiException)
            {
                context.Result = new ObjectResult(apiException.Message) { StatusCode = (int)apiException.StatusCode };
            }
        }
    }
}

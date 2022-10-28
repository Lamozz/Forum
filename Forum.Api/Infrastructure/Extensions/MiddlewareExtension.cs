using Forum.Api.Infrastructure.Middlewares;

namespace Forum.Api.Infrastructure.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseExceptionLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionLoggerMiddleware>();
        }

        public static IApplicationBuilder UseTransaction(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TransactionMiddleware>();
        }
    }
}

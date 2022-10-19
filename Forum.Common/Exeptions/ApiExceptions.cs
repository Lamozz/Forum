using System.Net;

namespace Forum.Common.Exeptions
{
    public class ApiExceptions : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ApiExceptions(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

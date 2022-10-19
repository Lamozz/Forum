using System.Net;

namespace Forum.Common.Exeptions
{
    public class NotFoundException : ApiExceptions
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {

        }
    }
}

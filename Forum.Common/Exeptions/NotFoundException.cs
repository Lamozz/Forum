using System.Net;

namespace Forum.Common.Exeptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message)
        {

        }
    }
}

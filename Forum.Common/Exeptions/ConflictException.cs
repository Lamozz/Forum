using Forum.Common.Exeptions;
using System.Net;

namespace Forum.Common.Exeptions
{
    public class ConflictException : ApiException
    {
        public ConflictException(string message) : base(HttpStatusCode.Conflict, message)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Common.Exeptions
{
    public class ServiceUnaviableException : ApiException
    {
        public ServiceUnaviableException(string message) : base(HttpStatusCode.ServiceUnavailable, message)
        {
        }
    }
}

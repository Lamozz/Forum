﻿using System.Net;

namespace Forum.Common.Exeptions
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ApiException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}

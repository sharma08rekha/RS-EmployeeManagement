using System;
using System.Net;

namespace Common
{
    public class APIException : Exception
    {
        public HttpStatusCode? StatusCode { get; set; }

        public string AdditionalData { get; set; }

        public APIException(HttpStatusCode statusCode, string additionalData) : base()
        {
            this.StatusCode = statusCode;
            this.AdditionalData = additionalData;
        }
    }
}

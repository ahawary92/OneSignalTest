using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Util
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}

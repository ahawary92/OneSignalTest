using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Util
{
    public interface IApiHelper
    {
        Dictionary<string, string> Headers { get; }
        ApiResponse<TReturnType> Delete<TReturnType>(string url);
        ApiResponse<TReturnType> Get<TReturnType>(string url);
        ApiResponse<TReturnType> Post<TReturnType>(string Url, object data);
        ApiResponse<TReturnType> Put<TReturnType>(string url, object data);
    }
}

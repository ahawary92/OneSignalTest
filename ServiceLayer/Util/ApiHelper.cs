using Core.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ServiceLayer.Util
{
    public class ApiHelper : IApiHelper
    {
        public Dictionary<string, string> Headers { get; }

        public ApiHelper()
        {
            Headers = new Dictionary<string, string>();
        }

        public ApiResponse<TReturnType> Get<TReturnType>(string url)
        {
            HttpResponseMessage sendFunc(HttpClient client, HttpContent content)
            {
                return client.GetAsync(url).Result;
            }

            return SendRequest<TReturnType>(sendFunc);
        }

        public ApiResponse<TReturnType> Post<TReturnType>(string url, object data)
        {
            HttpResponseMessage sendFunc(HttpClient client, HttpContent content)
            {

                return client.PostAsync(url, content).Result;
            }

            return SendRequest<TReturnType>(sendFunc, data);
        }

        public ApiResponse<TReturnType> Put<TReturnType>(string url, object data)
        {
            HttpResponseMessage sendFunc(HttpClient client, HttpContent content)
            {
                return client.PutAsync(url, content).Result;
            }

            return SendRequest<TReturnType>(sendFunc, data);
        }

        public ApiResponse<TReturnType> Delete<TReturnType>(string url)
        {
            HttpResponseMessage sendFunc(HttpClient client, HttpContent content)
            {
                return client.DeleteAsync(url).Result;
            }

            return SendRequest<TReturnType>(sendFunc);
        }

        private ApiResponse<TReturnType> SendRequest<TReturnType>(Func<HttpClient, HttpContent, HttpResponseMessage> sendFunc, object data = null)
        {
            var apiResponse = new ApiResponse<TReturnType>();
            using (var client = new HttpClient())
            {
                foreach (string header in Headers.Keys)
                {
                    if (header == "authorization")
                    {
                        client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(Headers[header]);
                    }
                    else
                    {
                        client.DefaultRequestHeaders.Add(header, Headers[header]);
                    }
                }

                StringContent httpContent = null;
                if (data != null)
                {
                    string jsonData = JsonConvert.SerializeObject(data);
                    httpContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage httpResponse = sendFunc.Invoke(client, httpContent);
                if (httpResponse.Content != null)
                {
                    apiResponse.StatusCode = httpResponse.StatusCode;

                    string responseJson = httpResponse.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(responseJson))
                    {
                        TReturnType response = JsonConvert.DeserializeObject<TReturnType>(responseJson);
                        apiResponse.Data = response;
                    }
                }
            }

            return apiResponse;
        }
    }
}

using Core.Domain;
using Core.Services;
using Core.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;

namespace ServiceLayer.Services
{
    public class OneSignalService : IOneSignalService
    {
        private readonly IApiHelper _apiHelper;
        private readonly IConfiguration _configuration;
        private string _baseUrl = string.Empty;
        private string _appId = string.Empty;
        private string _restAPIKey = string.Empty;

        public OneSignalService(IApiHelper apiHelper, IConfiguration configuration)
        {
            _apiHelper = apiHelper;
            _configuration = configuration;
            _baseUrl = _configuration["OneSignal:BaseUrl"];
            _appId = _configuration["OneSignal:APPID"];
            _restAPIKey = _configuration["OneSignal:RESTAPIKEY"];
            _apiHelper.Headers["authorization"] = $"Basic {_restAPIKey}";
        }

        public App CreateApp(App oneSignalApp)
            => PostData<App>(_baseUrl, oneSignalApp);

        public App UpdateApp(App oneSignalApp)
             => PutData<App>(_baseUrl, oneSignalApp);

        public List<App> ViewAllApps()
            => GetAllData<List<App>>(_baseUrl);

        public App ViewAppById(string id)
            => GetDataById<App>(_baseUrl, id);

        #region Web Client Helper

        private TResponse GetAllData<TResponse>(string url) where TResponse : class
        {
            TResponse response = null;
            try
            {
                ApiResponse<TResponse> apiResponse = _apiHelper.Get<TResponse>($"{url}");
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                    response = apiResponse.Data;
                else
                    throw new Exception("Something went wrong");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        private TResponse GetDataById<TResponse>(string url, string id) where TResponse : class
        {
            TResponse response = null;
            try
            {
                ApiResponse<TResponse> apiResponse = _apiHelper.Get<TResponse>($"{url}/{id}");
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                    response = apiResponse.Data;
                else
                    throw new Exception("Something went wrong");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        private TResponse PostData<TResponse>(string url, object data) where TResponse : class
        {
            TResponse response = null;
            try
            {
                ApiResponse<TResponse> apiResponse = _apiHelper.Post<TResponse>($"{url}", data);
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    response = apiResponse.Data;
                }
                else
                    throw new Exception("Something went wrong");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        private TResponse PutData<TResponse>(string url, object data) where TResponse : class
        {
            TResponse response = null;
            try
            {
                ApiResponse<TResponse> apiResponse = _apiHelper.Put<TResponse>($"{url}", data);
                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    response = apiResponse.Data;
                }
                else
                    throw new Exception("Something went wrong");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        #endregion Web Client Helper
    }
}

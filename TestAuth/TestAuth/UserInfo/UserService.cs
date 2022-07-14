using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestAuth.UserInfo
{
    public class UserService
    {

        /// <summary>
        /// GetHttpResponse
        /// </summary>
        /// <param name="userURL"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private Task<HttpResponseMessage> GetHttpResponse(string userURL, string accessToken)
        {
            try
            {
                var httpClient = new HttpClient();
                Uri userInfoUrl = new Uri(userURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(accessToken))
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                httpClient.BaseAddress = userInfoUrl;
                var httpTResponseAsync = httpClient.PostAsync(userInfoUrl, null);               
                return httpTResponseAsync;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <param name="userURL"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public UserData GetUserInfo(string userURL, string accessToken)
        {

            var  httpResponse = GetHttpResponse(userURL, accessToken);
            var  httpResponseResult = httpResponse.Result;
            string userJsonData = httpResponseResult.Content.ReadAsStringAsync().Result;
            var userData = JsonConvert.DeserializeObject<UserData>(userJsonData);
            return userData;
        }
    }
}
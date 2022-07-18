using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace TestAuth.UserInfo
{
    public class UserServiceWithWebClient
    {
        /// <summary>
        /// GetUserData
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public UserData GetUserData(string url, string accessToken)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var jsonResponse = GetWebRessponse(url, accessToken);
                UserData userData = JsonConvert.DeserializeObject<UserData>(jsonResponse);
                return userData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// WebRessponse
        /// </summary>
        /// <param name="url"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private string GetWebRessponse(string url, string accessToken)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = @"application/json";
            request.Accept = @"application/json";

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Add("Authorization", "Bearer " + accessToken);
            }
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    throw new JsonException(reader.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                return "Unhandled Error while checking User Info in Auth." + ex.Message;
            }
        }
    }
}
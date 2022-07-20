using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace SkillMineAuth
{


    public class TokenService
    {
        public TokenService()
        {

        }

        /// <summary>
        /// GetResult
        /// </summary>
        /// <param name="token"></param>
        /// <param name="rules"></param>
        /// <param name="Url"></param>
        /// <returns></returns>
        public dynamic GetResult(string token, dynamic rules, string Url)
        {
            var request = WebRequest.Create(Url);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            request.ContentType = "application/json";
            request.Method = "POST";
            string basicAuth = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("2ce60737-8596-465b-96b2-e6e3bf95a96e" + ":" + "110ccf54-e086-4822-bdb5-767b150752c2"));
            // "ZjhkNWEzZDMtMjU5MS00Zjg5LTk4MTgtMjg2NTdjMTQxOTQxOjI5YTM0NTgxLTQxNDctNGM3ZC1iN2IzLWVkOTBlZTg2ZWI4YQ==";
            request.Headers.Add("Authorization", "Basic " + basicAuth);

            var data = new
            {
                token = token,   //"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijg5NjliMGUxLWY5NjItNGI5YS1hNDU2LWYwODIzZjBlMTlmOCJ9.eyJzdWIiOiJiMWM5Njc2YS1kOWY1LTRjZjAtYTNmYy1jMmQ0OWJkZTA2YWUiLCJuYW1lIjoiU3lzdGVtIFVzZXIiLCJlbWFpbCI6InN5c3RlbXVzZXJAc2tpbGwtbWluZS5jb20iLCJpc3ViIjoiYTYwMTg1NTItODA0OS00MmMxLTlhNmQtNzRjYzVmZTI1NmZmIiwiaXNzIjoiaHR0cHM6Ly9tYW5hZ2VtZW50dGVzdC1hY2NvdW50cy1hcGkuY29tcGx5bWVudC5jb20iLCJhdWQiOiI2NDJmMmY0OC1lMTFjLTRkNzUtOTI3Yi04NDUxYTFmZTliMTMiLCJleHAiOjE2NDUwMjUyNzcsImlhdCI6MTY0NDkzODg3NywibGlhdCI6MTY0NDg5OTI2NSwiYXV0aF90aW1lIjoxNjQ0OTM4ODc3LCJhbXIiOlsiMCJdLCJhY3IiOiIxIiwianRpIjoiOWMwMDBiNzQtNzlkZC00MDczLTg5N2ItNzk0ZDJjOTNlZGZmIiwiZ3JvdXBzIjpbeyJyb2xlcyI6WyJhdXRoX2FkbWluIl0sImdyb3VwX2lkIjoiYXV0aF9hZG1pbnMiLCJncm91cF9uYW1lIjoiQURNSU4ifSx7InJvbGVzIjpbImF1dGhfdXNlciJdLCJncm91cF9pZCI6ImF1dGhfdXNlcnMiLCJncm91cF9uYW1lIjoiVVNFUiJ9LHsicm9sZXMiOlsiYWRtaW4iXSwiZ3JvdXBfaWQiOiJhdXRoX21hbmFnZW1lbnQiLCJncm91cF9uYW1lIjoiYXV0aF9tYW5hZ2VtZW50In1dLCJzY29wZXMiOlsib3BlbmlkIiwicHJvZmlsZSIsImVtYWlsIl0sInNpZCI6IjcyZGRjZmE4LTQ3YTQtNDY5YS04ZjNhLTFmYWZmY2E4ODZlMiIsInVhX2hhc2giOiI5MTliM2NjM2RkZTg4MTc1OGM0YWEyY2JhZjYyZjdmNiIsImN0ciI6IjU4NzI1ZjczLTQ0ZGYtNDIxNy04YTFkLTFkNjE5NGQ4OGM4NiIsImRyIjoiIn0.xg5brVeR3cCUpK0tQQA1zTT686rr3G24sc5zGG9Ba6Gpn8w2VZzQ2o9ThJNeI0LQqVO3iqirDXb4GDQe7nr1FrxcmRiCz-exwbj1nhYXNqnTEhaZQ3-2BYYwBKXxnRfvMKv0_5X2I1u7bz6UCBxaZRtJLMTLKU1EPqcnoRYFEn1pINGjFzd07p5PEyTwwE9_soMNlPC67jPnFhFxCz0TNO59jZljr8Fs0Thlhy97iDjFxK6IkEX9HCWASHxG4gHLR0DlurZ1uppEUF_WT0FyGdg7cNacw9KjVkbErEM2RDxUH_hI_h7COqB-4RDlivsId4-JfvPs21SBjYI4O3OLSg",
                token_type_hint = "access_token",
                validation_rules = rules

            };

            var dataString = JsonConvert.SerializeObject(data);
            request.ContentLength = dataString.Length;
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(dataString);
            }
            string result = "";
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        var myStreamReader = new StreamReader(responseStream, Encoding.Default);
                        var resultEntity = myStreamReader.ReadToEnd();
                        result = resultEntity; 

                    }
                    responseStream.Close();
                }
                response.Close();
            }

            return JsonConvert.DeserializeObject(result);
        }
    }
}


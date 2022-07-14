using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace AuthTest.Code.Filters
{
    internal class TokenService
    {
        public TokenService()
        {
        }

        const string Url = "https://demo-accounts-api.skill-mine.com/token-srv/introspect";
//        public dynamic GetResult(string token)
//        {
//            var client = new RestClient("https://demo-accounts-api.skill-mine.com/token-srv/introspect");
//            client.Timeout = -1;
//            var request = new RestRequest(Method.POST);
//            request.AddHeader("Authorization", "Basic MmNlNjA3MzctODU5Ni00NjViLTk2YjItZTZlM2JmOTVhOTZlOjExMGNjZjU0LWUwODYtNDgyMi1iZGI1LTc2N2IxNTA3NTJjMg==");
//            request.AddHeader("Content-Type", "application/json");
//            var body = @"{
//" + "\n" +
//            @"    ""token"": ""eyJhbGciOiJSUzI1NiIsImtpZCI6IjA2YzllZTkwLTA3OTQtNDIxMS1hMjZhLTM5ZjBlNDExYzQ3YyJ9.eyJzdWIiOiJiMWM5Njc2YS1kOWY1LTRjZjAtYTNmYy1jMmQ0OWJkZTA2YWUiLCJuYW1lIjoiU3lzdGVtIFVzZXIiLCJlbWFpbCI6InN5c3RlbXVzZXJAc2tpbGwtbWluZS5jb20iLCJpc3ViIjoiMDc2ZWU1YTItNjkwNi00NjZlLTg3YTEtY2MwZWVkMmYxYmE4IiwiaXNzIjoiaHR0cHM6Ly9kZW1vLWFjY291bnRzLWFwaS5za2lsbC1taW5lLmNvbSIsImF1ZCI6Ijk5YmUyZTI5LTRjZGQtNDM1Ni05MDg0LWIxNTRjYmJiNDU4MCIsImV4cCI6MTY1NDA3NzgwMCwiaWF0IjoxNjUzOTkxNDAwLCJsaWF0IjoxNjUzNTgyNzE4LCJhdXRoX3RpbWUiOjE2NTM5OTE0MDAsImFtciI6WyIwIl0sImFjciI6IjEiLCJqdGkiOiIzN2M1OTQ1MC0zNzZjLTQ2ZGYtYjM4OC1iZjA3MDYxYzE0NWEiLCJncm91cHMiOlt7InJvbGVzIjpbImF1dGhfYWRtaW4iXSwiZ3JvdXBfaWQiOiJhdXRoX2FkbWlucyIsImdyb3VwX25hbWUiOiJBRE1JTiJ9LHsicm9sZXMiOlsiYXV0aF91c2VyIl0sImdyb3VwX2lkIjoiYXV0aF91c2VycyIsImdyb3VwX25hbWUiOiJVU0VSIn1dLCJzY29wZXMiOlsib3BlbmlkIiwicHJvZmlsZSIsImVtYWlsIiwidXNlcl9pbmZvX2FsbCJdLCJzaWQiOiI1MTBiYmU2OC02ODg2LTQ3YzMtYjM0MC0zOWFjYmRiNDFmZDEiLCJ1YV9oYXNoIjoiMWFmM2Q2ZDRmYmI3OTQ3ZDEwN2IwMTcwYTMwOWY1MTAiLCJjdHIiOiJmZDE0OTgxMS00OWE2LTQ2ODctOWM0OS1mNTIwMDYzMmU4MWMiLCJkciI6IiJ9.ZDvRIrL8CaQzIbklcBnyTcFYZVaDfSRc9DnHHZU4tIWRrxrg-cXCbis7dUGu8n0fWtsQ3YPmsylm4vA2ipy3zikr_vI2BldIis9S_oicPAJUdrLg1hycnBe9RH6BFXzqA3BG75WznmdWW9dk7cr3PN93WtVSixSX9XFEsclHydQFySHjT0d7AXr33kj6jUmHoL1yAe5OMEq6UhOnan6YWSNePu1X-6i0ImEX7B0_vWFRVx_2Fc0NASqMfozYvwvl7S90DN0VnUEVen_qXGA-LOvL7KMYWyMkMPInwnjLVNenSr0TIk00fL46QJj-JC32JSkUWlBvx-uwGtkJO5IAVg"",
//" + "\n" +
//            @"    ""token_type_hint"": ""access_token""
//" + "\n" +
//            @"}";
//            request.AddParameter("application/json", body, ParameterType.RequestBody);
//            IRestResponse response = client.Execute(request);
//            Console.WriteLine(response.Content);
//        }

        public dynamic GetResult(string token, dynamic rules)
        {
            var request = WebRequest.Create(Url);

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            request.ContentType = "application/json";
            request.Method = "POST";
            string basicAuth = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("2ce60737-8596-465b-96b2-e6e3bf95a96e" + ":" + "110ccf54-e086-4822-bdb5-767b150752c2")) ; 
            // "ZjhkNWEzZDMtMjU5MS00Zjg5LTk4MTgtMjg2NTdjMTQxOTQxOjI5YTM0NTgxLTQxNDctNGM3ZC1iN2IzLWVkOTBlZTg2ZWI4YQ==";
            request.Headers.Add("Authorization", "Basic " + basicAuth);

            var data = new
            {
                token =  token,   //"eyJhbGciOiJSUzI1NiIsImtpZCI6Ijg5NjliMGUxLWY5NjItNGI5YS1hNDU2LWYwODIzZjBlMTlmOCJ9.eyJzdWIiOiJiMWM5Njc2YS1kOWY1LTRjZjAtYTNmYy1jMmQ0OWJkZTA2YWUiLCJuYW1lIjoiU3lzdGVtIFVzZXIiLCJlbWFpbCI6InN5c3RlbXVzZXJAc2tpbGwtbWluZS5jb20iLCJpc3ViIjoiYTYwMTg1NTItODA0OS00MmMxLTlhNmQtNzRjYzVmZTI1NmZmIiwiaXNzIjoiaHR0cHM6Ly9tYW5hZ2VtZW50dGVzdC1hY2NvdW50cy1hcGkuY29tcGx5bWVudC5jb20iLCJhdWQiOiI2NDJmMmY0OC1lMTFjLTRkNzUtOTI3Yi04NDUxYTFmZTliMTMiLCJleHAiOjE2NDUwMjUyNzcsImlhdCI6MTY0NDkzODg3NywibGlhdCI6MTY0NDg5OTI2NSwiYXV0aF90aW1lIjoxNjQ0OTM4ODc3LCJhbXIiOlsiMCJdLCJhY3IiOiIxIiwianRpIjoiOWMwMDBiNzQtNzlkZC00MDczLTg5N2ItNzk0ZDJjOTNlZGZmIiwiZ3JvdXBzIjpbeyJyb2xlcyI6WyJhdXRoX2FkbWluIl0sImdyb3VwX2lkIjoiYXV0aF9hZG1pbnMiLCJncm91cF9uYW1lIjoiQURNSU4ifSx7InJvbGVzIjpbImF1dGhfdXNlciJdLCJncm91cF9pZCI6ImF1dGhfdXNlcnMiLCJncm91cF9uYW1lIjoiVVNFUiJ9LHsicm9sZXMiOlsiYWRtaW4iXSwiZ3JvdXBfaWQiOiJhdXRoX21hbmFnZW1lbnQiLCJncm91cF9uYW1lIjoiYXV0aF9tYW5hZ2VtZW50In1dLCJzY29wZXMiOlsib3BlbmlkIiwicHJvZmlsZSIsImVtYWlsIl0sInNpZCI6IjcyZGRjZmE4LTQ3YTQtNDY5YS04ZjNhLTFmYWZmY2E4ODZlMiIsInVhX2hhc2giOiI5MTliM2NjM2RkZTg4MTc1OGM0YWEyY2JhZjYyZjdmNiIsImN0ciI6IjU4NzI1ZjczLTQ0ZGYtNDIxNy04YTFkLTFkNjE5NGQ4OGM4NiIsImRyIjoiIn0.xg5brVeR3cCUpK0tQQA1zTT686rr3G24sc5zGG9Ba6Gpn8w2VZzQ2o9ThJNeI0LQqVO3iqirDXb4GDQe7nr1FrxcmRiCz-exwbj1nhYXNqnTEhaZQ3-2BYYwBKXxnRfvMKv0_5X2I1u7bz6UCBxaZRtJLMTLKU1EPqcnoRYFEn1pINGjFzd07p5PEyTwwE9_soMNlPC67jPnFhFxCz0TNO59jZljr8Fs0Thlhy97iDjFxK6IkEX9HCWASHxG4gHLR0DlurZ1uppEUF_WT0FyGdg7cNacw9KjVkbErEM2RDxUH_hI_h7COqB-4RDlivsId4-JfvPs21SBjYI4O3OLSg",
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
                        result = resultEntity; // myStreamReader.ReadToEnd();

                   }
                    responseStream.Close();
                }
                response.Close();
            } 

            return JsonConvert.DeserializeObject( result );
        }
    }
}
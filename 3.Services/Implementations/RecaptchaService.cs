using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class RecaptchaService : IAuthService
    {
        [DataContract]
        private class RecaptchaResponse
        {
            [DataMember(Name = "success")]
            public Boolean Success { get; set; }

            [DataMember(Name = "challenge_ts")]
            public String ChallengeTs { get; set; }

            [DataMember(Name = "hostname")]
            public String Hostname { get; set; }

            [DataMember(Name = "error-codes")]
            public String[] ErrorCodes { get; set; }
        }

        private static String _secret = "6Ldv8oIUAAAAAPnY5lHswV17LpPlCSApcpuwd3wQ";
        private static String _endpoint = "https://www.google.com/recaptcha/api/siteverify";
        private static String _secretParam = "secret";
        private static String _repsonseParam = "response";

        private FormUrlEncodedContent GetParams(String token)
        {
            IDictionary<String, String> requestParams = new Dictionary<String, String>()
            {
               { _secretParam, _secret },
               { _repsonseParam, token }
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(requestParams);

            return content;
        }

        private async Task<RecaptchaResponse> GetResponseAsync(String token)
        {
            HttpClient client = new HttpClient();
            FormUrlEncodedContent requestParams = this.GetParams(token);

            HttpResponseMessage response = await client.PostAsync(_endpoint, requestParams);
            String responseString = await response.Content.ReadAsStringAsync();

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RecaptchaResponse));
                RecaptchaResponse recaptchaResponse = (RecaptchaResponse)serializer.ReadObject(stream);

                return recaptchaResponse;
            }
        }

        public Boolean IsUserAuthorizedAsync(string token)
        {
            Task<RecaptchaResponse> recaptchaResponse = this.GetResponseAsync(token);

            return recaptchaResponse.Result.Success;
        }
    }
}

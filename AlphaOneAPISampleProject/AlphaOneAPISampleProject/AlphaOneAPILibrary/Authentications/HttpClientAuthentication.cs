using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Authentications
{
    class HttpClientAuthentication : AuthenticationInterface
    {
        private static AuthenticateEntity authEntity;
        private static String webResponse;

        public void setAuthenticateEntity(AuthenticateEntity authEnt)
        {
            authEntity = authEnt;
        }

        public void Authenticate()
        {
            Task<String> task = Task.Run<String>(async () => await authenticate());
            task.Wait();
            webResponse = task.Result.ToString();
        }

        public String getResponse()
        {
            return webResponse;
        }

        static async Task<String> authenticate()
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "username", authEntity.getUsername() },
                { "key", authEntity.getPassword() }
            };
            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync((authEntity.getBaseUrl() + "/v1/authenticate"), content);
            var json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}

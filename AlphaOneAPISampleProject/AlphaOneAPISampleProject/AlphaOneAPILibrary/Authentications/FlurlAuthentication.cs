using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Authentications
{
    class FlurlAuthentication : AuthenticationInterface
    {
        private static AuthenticateEntity authEntity;
        private static String HttpRequestResponse;

        public void setAuthenticateEntity(AuthenticateEntity authEnt)
        {
            authEntity = authEnt;
        }

        public void Authenticate()
        {
            Task auth = processAuthentication();
            auth.Wait();
        }

        public String getResponse()
        {
            return HttpRequestResponse;
        }

        public async Task processAuthentication()
        {
            var json = await (
                authEntity.getBaseUrl() + "/v1/authenticate"
            ).PostUrlEncodedAsync(
                new
                {
                    username = authEntity.getUsername(),
                    key = authEntity.getPassword()
                }
            ).ReceiveString();

            HttpRequestResponse = json;
        }
    }
}

using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Authentications;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary
{
    class AuthenticationService
    {
        public static String AUTH_TYPE_FLURL = "flurl";
        public static String AUTH_TYPE_HTTP_CLIENT = "http_client";
        public static String AUTH_TYPE_WEB_REQUEST = "web_request";

        private static String AUTH_TYPE = "flurl";
        private static AuthenticateEntity authEntity;

        public void setAuthenticationType(String auth_type)
        {
            AUTH_TYPE = auth_type;
        }

        public void setAuthenticateEntity(AuthenticateEntity auth)
        {
            authEntity = auth;
        }

        public String Authenticate()
        {
            AuthenticationInterface authObject;

            switch(AUTH_TYPE)
            {
                case "flurl":
                    authObject = new FlurlAuthentication();
                    break;
                case "http_client":
                    authObject = new HttpClientAuthentication();
                    break;
                case "web_request":
                    authObject = new WebRequestAuthentication();
                    break;
                default:
                    throw new Exception("ERROR! INVALID AUTH_TYPE!");
            }

            authObject.setAuthenticateEntity(authEntity);
            authObject.Authenticate();

            return authObject.getResponse();
        }
    }
}

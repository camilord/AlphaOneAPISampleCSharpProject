﻿using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using System;
using System.Net;
using System.Text;
using System.IO;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Authentications
{
    class WebRequestAuthentication : AuthenticationInterface
    {
        private static AuthenticateEntity authEntity;
        private static String webResponse;

        public void setAuthenticateEntity(AuthenticateEntity authEnt)
        {
            authEntity = authEnt;
        }

        public void Authenticate()
        {
            String url = (authEntity.getBaseUrl() + "/v1/authenticate");
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            // manual concat credentials
            //String post_data = "username=" + authEntity.getUsername() + "&key=" + authEntity.getPassword();

            // using string builder
            StringBuilder formData = new StringBuilder();
            formData.AppendFormat("{0}={1}", "username", authEntity.getUsername());
            formData.AppendFormat("&{0}={1}", "key", authEntity.getPassword());
            String post_data = formData.ToString();

            Stream stream = request.GetRequestStream();
            byte[] postArray = Encoding.ASCII.GetBytes(post_data);
            stream.Write(postArray, 0, postArray.Length);
            stream.Close();

            StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream());
            string Result = sr.ReadToEnd();

            webResponse = Result.ToString();
        }

        public String getResponse()
        {
            return webResponse;
        }
    }
}

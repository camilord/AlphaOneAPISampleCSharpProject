using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.Util
{
    class WebRequestUtil
    {
        private static AuthorizationEntity authorizationEntity;

        public WebRequestUtil(AuthorizationEntity authorization)
        {
            authorizationEntity = authorization;
        }

        public String postRequest(String url, Dictionary<string, string> post_data)
        {
            return processRequest(url, "POST", post_data);
        }

        public String getRequest(String url, Dictionary<string, string> post_data)
        {
            return processRequest(url, "GET", post_data);
        }

        private String processRequest(String url, String method_request, Dictionary<string, string> post_data)
        {
            // using string builder
            StringBuilder formData = new StringBuilder();
            int ctr = 0;
            if (post_data.Count == 0)
            {
                TimeSpan t = DateTime.UtcNow - new DateTime(
                    DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day
                );
                int secondsSinceEpoch = (int)t.TotalSeconds;
                post_data.Add("t", secondsSinceEpoch.ToString());
            }
            foreach (KeyValuePair<string, string> entry in post_data)
            {
                // do something with entry.Value or entry.Key
                if (ctr == 0)
                {
                    formData.AppendFormat("{0}={1}", entry.Key.ToString(), entry.Value.ToString());
                }
                else
                {
                    formData.AppendFormat("&{0}={1}", entry.Key.ToString(), entry.Value.ToString());
                }
                ctr++;
            }
            String flatten_post_data = formData.ToString();

            if (method_request.ToUpper() == "GET")
            {
                url = url + "?" + flatten_post_data;
            }

            WebRequest request = WebRequest.Create(url);
            request.Method = method_request;
            /**
             * dont add content-type header on authenticate
             */
            if (!url.Contains("/authenticate"))
            {
                WebHeaderCollection whc = new WebHeaderCollection();
                whc.Add("Auth-username", authorizationEntity.getUsername());
                whc.Add("Auth-session-key", authorizationEntity.getSessionKey());
                request.Headers = whc;
            }
            request.ContentType = "application/x-www-form-urlencoded";

            if (method_request.ToUpper() == "POST")
            {
                Stream stream = request.GetRequestStream();
                byte[] postArray = Encoding.UTF8.GetBytes(flatten_post_data);
                stream.Write(postArray, 0, postArray.Length);
                stream.Close();
            }

            string Result;
            try
            {
                //Console.WriteLine(request.Headers.ToString());
                StreamReader sr = new StreamReader(request.GetResponse().GetResponseStream());
                Result = sr.ReadToEnd();
            } catch(WebException e)
            {
                Console.WriteLine(e.Message);
                Result = "[]";
            }
            

            String wrResponse = Result.ToString();
            return wrResponse;
        }
    }
}

using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Util;
using System;
using System.Collections.Generic;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList
{
    abstract class ProjectList
    {
        protected String processList(String url, AuthorizationEntity authorization)
        {
            WebRequestUtil wrUtil = new WebRequestUtil(authorization);
            Dictionary<string, string> post_data = new Dictionary<string, string>();
            String response = wrUtil.getRequest(url, post_data);

            return response;
        }
    }
}

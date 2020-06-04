using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList
{
    class AlphaGoProjectList : ProjectList, ProjectListInterface
    {
        AuthorizationEntity authorizationEntity;

        public AlphaGoProjectList(AuthorizationEntity auth)
        {
            authorizationEntity = auth;
        }

        public ProjectListResponse getList(int offset = 0)
        {
            String url = authorizationEntity.getBaseUrl() + "/v1/alphago/list";
            if (offset > 0)
            {
                url = url + "/" + offset.ToString();
            }
            String response = processList(url, authorizationEntity);

            ProjectListResponse obj = JsonConvert.DeserializeObject<ProjectListResponse>(response);
            return obj;
        }

        public MarkResponse markDone(String alpha_id, String flag, String request_key)
        {
            String url = authorizationEntity.getBaseUrl();
            url += "/v1/alphago/list/" + alpha_id + "/mark";

            WebRequestUtil wrUtil = new WebRequestUtil(authorizationEntity);

            Dictionary<string, string> post_data = new Dictionary<string, string>();
            post_data.Add("flag", flag);
            post_data.Add("request_key", request_key);

            String response = wrUtil.postRequest(url, post_data);
            MarkResponse objResponse = JsonConvert.DeserializeObject<MarkResponse>(response);

            return objResponse;
        }
    }
}

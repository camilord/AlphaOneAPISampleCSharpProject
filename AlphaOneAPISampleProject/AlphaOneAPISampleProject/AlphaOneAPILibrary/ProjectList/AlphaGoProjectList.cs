using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;
using Newtonsoft.Json;
using System;

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
    }
}

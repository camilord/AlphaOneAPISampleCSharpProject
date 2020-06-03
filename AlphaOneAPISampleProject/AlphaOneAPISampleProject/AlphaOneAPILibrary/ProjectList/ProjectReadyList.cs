using System;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;
using Newtonsoft.Json;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList
{
    class ProjectReadyList : ProjectList, ProjectListInterface
    {
        AuthorizationEntity authorizationEntity;
        private static String FormID;

        /**
         * @param String formId - please refer to APIConstants class
         * 
         */
        public ProjectReadyList(AuthorizationEntity auth, String formId = "all")
        {
            authorizationEntity = auth;
            FormID = formId;
        }

        public ProjectListResponse getList(int offset = 0)
        {
            String url = authorizationEntity.getBaseUrl() + "/v1/projects/ready/" + FormID;
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

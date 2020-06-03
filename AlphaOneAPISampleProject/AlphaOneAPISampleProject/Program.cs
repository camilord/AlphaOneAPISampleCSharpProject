using AlphaOneAPISampleProject.AlphaOneAPILibrary;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;
using Newtonsoft.Json;
using System;

namespace AlphaOneAPISampleProject
{
    class Program
    {
        public static AuthorizationEntity AUTHORIZATION;

        static void Main(string[] args)
        {
            AuthenticateEntity authEntity = new AuthenticateEntity();
            authEntity.setBaseUrl("https://council-api.abcs.co.nz");
            authEntity.setUsername("ACCOUNT_HERE");
            authEntity.setPassword("SECRET_KEY_HERE");

            AuthenticationService auth = new AuthenticationService();
            auth.setAuthenticateEntity(authEntity);

            /**
             * You have 3 Authentication types to choose
             *  - using nuget package Flurl.Http
             *  - using HttpClient class
             *  - lastly using WebRequest
             * by default, its set to Flurl.Http
             */
            // auth.setAuthenticationType(AuthenticationService.AUTH_TYPE_FLURL);
            // auth.setAuthenticationType(AuthenticationService.AUTH_TYPE_HTTP_CLIENT);
            // auth.setAuthenticationType(AuthenticationService.AUTH_TYPE_WEB_REQUEST);

            String response = auth.Authenticate();
            Console.WriteLine(response);

            // convert json string to object
            AuthenticationResponse result = JsonConvert.DeserializeObject<AuthenticationResponse>(response);

            /**
             * this will be the access class you need to use to fetch the project list or details
             */
            AUTHORIZATION = new AuthorizationEntity(
                authEntity.getBaseUrl(),
                authEntity.getUsername(), 
                result.session_key
            );


            /**
             * Demonstration on fetching the list of ACCEPTED projects
             */
            AcceptedProjectList AcceptedListObj = new AcceptedProjectList(AUTHORIZATION);
            ProjectListResponse project_list = AcceptedListObj.getList();
            Console.WriteLine(project_list.ToString());

            /**
             * Demonstration on fetching the list of Project Ready by Form projects
             * in this case, i specify to fetch all BC granted/issued only
             */
            ProjectReadyList ReadyListObj = new ProjectReadyList(
                AUTHORIZATION, 
                AlphaOneAPILibrary.Common.APIConstants.BuildingConsent
            );
            project_list = ReadyListObj.getList();
            Console.WriteLine(project_list.ToString());

            /**
             * Demonstration on fetching the list of ALPHA-GOGET Integration API Project List
             */
            AlphaGoProjectList agListObj = new AlphaGoProjectList(AUTHORIZATION);
            project_list = agListObj.getList();
            Console.WriteLine(project_list.ToString());
        }
    }
}

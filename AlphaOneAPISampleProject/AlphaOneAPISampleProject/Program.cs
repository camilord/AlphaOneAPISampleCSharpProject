using AlphaOneAPISampleProject.AlphaOneAPILibrary;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Common;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response.Objects;
using Newtonsoft.Json;
using System;

namespace AlphaOneAPISampleProject
{
    class Program
    {
        public static AuthorizationEntity AUTHORIZATION;

        static void Main(string[] args)
        {
            AppConfigService configService = new AppConfigService();
            AppConfig config = configService.getConfiguration();
            /**
             * instantiate the AuthenticateEntity to store your credentials
             * for the AlphaOne API
             */
            AuthenticateEntity authEntity = new AuthenticateEntity();
            authEntity.setBaseUrl(config.api_base_url);
            authEntity.setUsername(config.username);
            authEntity.setPassword(config.password);

            /**
             * instantiate auth service then start authenticating
             */
            AuthenticationService auth = new AuthenticationService(authEntity);

            /**
             * You have 3 Authentication types to choose
             *  - using nuget package Flurl.Http
             *  - using HttpClient class
             *  - lastly using WebRequest
             *  
             * by default, its set to Flurl.Http
             */
            // auth.setAuthenticationType(AuthenticationService.AUTH_TYPE_FLURL);
            // auth.setAuthenticationType(AuthenticationService.AUTH_TYPE_HTTP_CLIENT);
            auth.setAuthenticationType(AuthenticationService.AUTH_TYPE_WEB_REQUEST);

            String response = auth.Authenticate();
            Console.WriteLine(response + "\n");

            // convert json string to object
            AuthenticationResponse result = JsonConvert.DeserializeObject<AuthenticationResponse>(response);

            /**
             * this will be the access class you need to use 
             * to fetch the project list or details
             */
            AUTHORIZATION = new AuthorizationEntity(
                authEntity.getBaseUrl(),
                authEntity.getUsername(), 
                result.session_key
            );

            /**
             * instantiate ProjectListService class and get the project list
             * based on different options like
             *  - accepted project list
             *  - list of projects based on forms
             *    - like BC granted/issued form
             *    - CCC issued
             *    - VRFI/RFI/IR finalised
             *  - alpha-goget integration project list
             *  
             *  view the class and will give you bunch of options 
             *  to get the project list
             */
            ProjectListService list = new ProjectListService(AUTHORIZATION);
            ProjectListResponse objResponse = list.getAcceptedProjectList();
            Console.WriteLine("Total Projects: " + objResponse.Data.TotalProjects + "\n");
            MarkResponse markResponse;

            if (objResponse.Data.List.Length > 0)
            {
                foreach(ProjectListItemObject item in objResponse.Data.List)
                {
                    Console.WriteLine("AlphaID: " + item.AlphaID);
                    Console.WriteLine("ConsentID: " + item.ConsentNumber);
                    Console.WriteLine("Flag: " + item.ApplicationFlag);
                    Console.WriteLine("RequestKey: " + item.RequestKey);

                    Console.WriteLine("\nMarking as done ...");
                    markResponse = list.markAcceptedProjectAsDone(item.AlphaID, item.ApplicationFlag, item.RequestKey);
                    
                    Console.WriteLine("\tResult: " + markResponse.Result);
                    Console.WriteLine("\tMessage: " + markResponse.Message);
                    Console.WriteLine("\tTimestamp: " + markResponse.Timestamp);
                    if (markResponse.Result == "true")
                    {
                        Console.WriteLine("\tResponseID: " + markResponse.ResponseID);
                    }
                    
                    break;
                }
            }

            Console.WriteLine("\n\nTesting on ALPHAONE-GOCOUNCIL ...\n\n\n");

            /**
             * AlphaOne-GoCouncil Integration Sample
             */
            objResponse = list.getAlphaGoProjectList();
            Console.WriteLine("Total Projects: " + objResponse.Data.TotalProjects + "\n");

            if (objResponse.Data.List.Length > 0)
            {
                foreach (ProjectListItemObject item in objResponse.Data.List)
                {
                    Console.WriteLine("AlphaID: " + item.AlphaID);
                    Console.WriteLine("ConsentID: " + item.ConsentNumber);
                    Console.WriteLine("Flag: " + item.ApplicationFlag);
                    Console.WriteLine("RequestKey: " + item.RequestKey);

                    Console.WriteLine("\nMarking as done ...");
                    markResponse = list.markAlphaGoProjectAsDone(item.AlphaID, item.ApplicationFlag, item.RequestKey);

                    Console.WriteLine("\tResult: " + markResponse.Result);
                    Console.WriteLine("\tMessage: " + markResponse.Message);
                    Console.WriteLine("\tTimestamp: " + markResponse.Timestamp);
                    if (markResponse.Result == "true")
                    {
                        Console.WriteLine("\tResponseID: " + markResponse.ResponseID);
                    }

                    break;
                }
            }
        }
    }
}

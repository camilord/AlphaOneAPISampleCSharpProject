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
            /**
             * instantiate the AuthenticateEntity to store your credentials
             * for the AlphaOne API
             */
            AuthenticateEntity authEntity = new AuthenticateEntity();
            authEntity.setBaseUrl("https://council-api.abcs.co.nz");
            authEntity.setUsername("ACCOUNT_HERE");
            authEntity.setPassword("SECRET_KEY_HERE");

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
            // auth.setAuthenticationType(AuthenticationService.AUTH_TYPE_WEB_REQUEST);

            String response = auth.Authenticate();
            Console.WriteLine(response);

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
            Console.WriteLine(list.getAcceptedProjectList());
        }
    }
}

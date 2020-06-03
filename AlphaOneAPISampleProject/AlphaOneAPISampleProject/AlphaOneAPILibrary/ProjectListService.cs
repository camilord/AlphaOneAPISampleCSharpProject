using AlphaOneAPISampleProject.AlphaOneAPILibrary.Entity;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.ProjectList;
using AlphaOneAPISampleProject.AlphaOneAPILibrary.Response;

namespace AlphaOneAPISampleProject.AlphaOneAPILibrary
{
    class ProjectListService
    {
        private AuthorizationEntity authorizationEntity;
        public ProjectListService(AuthorizationEntity authEntity)
        {
            authorizationEntity = authEntity;
        }

        /**
        * Demonstration on fetching the list of ACCEPTED projects
        */
        public ProjectListResponse getAcceptedProjectList()
        {
            AcceptedProjectList AcceptedListObj = new AcceptedProjectList(authorizationEntity);
            ProjectListResponse project_list = AcceptedListObj.getList();
            return project_list;
        }

        /**
         * Demonstration on fetching the list of Project Ready by Form projects
         * in this case, i specify to fetch all BC granted/issued only
         */
        public ProjectListResponse getProjectReadyListOnBC()
        {
            return getProjectReadyListOn(Common.APIConstants.BuildingConsent);
        }

        /**
         * Demonstration on fetching the list of Project Ready by Form projects
         * in this case, i specify to fetch all CCC issued only
         */
        public ProjectListResponse getProjectReadyListOnCCC()
        {
            return getProjectReadyListOn(Common.APIConstants.CodeComplianceCertificate);
        }

        /**
         * Demonstration on fetching the list of Project Ready by Form projects
         * in this case, i specify to fetch all VRFI granted only
         */
        public ProjectListResponse getProjectReadyListOnVRFI()
        {
            return getProjectReadyListOn(Common.APIConstants.VRFI);
        }

        /**
         * Demonstration on fetching the list of Project Ready by Form projects
         * in this case, i specify to fetch all RFI granted only
         */
        public ProjectListResponse getProjectReadyListOnRFI()
        {
            return getProjectReadyListOn(Common.APIConstants.RFI);
        }

        /**
         * Demonstration on fetching the list of Project Ready by Form projects
         * in this case, i specify to fetch all IR granted only
         */
        public ProjectListResponse getProjectReadyListOnIR()
        {
            return getProjectReadyListOn(Common.APIConstants.InspectionReport);
        }

        /**
         * Demonstration on fetching the list of Project Ready by Form projects
         * in this case, i specify to fetch all specific form granted only
         */
        public ProjectListResponse getProjectReadyListOn(string formID = "all")
        {
            ProjectReadyList ReadyListObj = new ProjectReadyList(
                authorizationEntity,
                formID
            );
            ProjectListResponse project_list = ReadyListObj.getList();
            return project_list;
        }

        /**
         * Demonstration on fetching the list of ALPHA-GOGET Integration API Project List
         */
        public ProjectListResponse getAlphaGoProjectList()
        {
            AlphaGoProjectList agListObj = new AlphaGoProjectList(authorizationEntity);
            ProjectListResponse project_list = agListObj.getList();
            return project_list;
        }
    }
}

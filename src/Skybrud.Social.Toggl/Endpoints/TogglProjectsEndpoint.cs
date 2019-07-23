using Skybrud.Social.Toggl.Endpoints.Raw;
using Skybrud.Social.Toggl.Responses.Projects;

namespace Skybrud.Social.Toggl.Endpoints {

    public class TogglProjectsEndpoint {

        #region Properties

        public TogglService Service { get; }

        public TogglProjectsRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        public TogglProjectsEndpoint(TogglService service) {
            Service = service;
            Raw = service.Client.Projects;
        }

        #endregion

        #region Member methods

                
        public TogglCreateProjectResponse CreateProject(string name, int workspaceId) {
            return TogglCreateProjectResponse.Parse(Raw.CreateProject(name, workspaceId));
        }

        public TogglCreateProjectResponse CreateProject(string name, int workspaceId, int clientId) {
            return TogglCreateProjectResponse.Parse(Raw.CreateProject(name, workspaceId, clientId));
        }

        public TogglGetProjectsResponse GetProjects(int workspaceId) {
            return TogglGetProjectsResponse.Parse(Raw.GetProjects(workspaceId));
        }

        #endregion

    }

}
using Skybrud.Social.Toggl.Endpoints.Raw;
using Skybrud.Social.Toggl.Options.Projects;
using Skybrud.Social.Toggl.Responses.Projects;

namespace Skybrud.Social.Toggl.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Projects</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md</cref>
    /// </see>
    public class TogglProjectsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public TogglService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TogglProjectsRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        internal TogglProjectsEndpoint(TogglService service) {
            Service = service;
            Raw = service.Client.Projects;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Creates a new project with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the project to be created</param>
        /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#create-project</cref>
        /// </see> 
        public TogglProjectResponse CreateProject(string name, int workspaceId) {
            return TogglProjectResponse.Parse(Raw.CreateProject(name, workspaceId));
        }

        /// <summary>
        /// Creates a new project with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the project to be created</param>
        /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
        /// <param name="clientId">The ID of the parent client.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#create-project</cref>
        /// </see>
        public TogglProjectResponse CreateProject(string name, int workspaceId, int clientId) {
            return TogglProjectResponse.Parse(Raw.CreateProject(name, workspaceId, clientId));
        }

        /// <summary>
        /// Creates a new project based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
        public TogglProjectResponse CreateProject(TogglCreateProjectsOptions options) {
            return TogglProjectResponse.Parse(Raw.CreateProject(options));
        }

        /// <summary>
        /// Updates the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
        public TogglProjectResponse UpdateProject(TogglUpdateProjectOptions options) {
            return TogglProjectResponse.Parse(Raw.UpdateProject(options));
        }

        #endregion

    }

}
using Skybrud.Social.Toggl.Endpoints.Raw;
using Skybrud.Social.Toggl.Options.Projects;
using Skybrud.Social.Toggl.Options.Workspaces;
using Skybrud.Social.Toggl.Responses.Projects;

namespace Skybrud.Social.Toggl.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Workspaces</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md</cref>
    /// </see>
    public class TogglWorkspacesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public TogglService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TogglWorkspacesRawEndpoint Raw => Service.Client.Workspaces;

        #endregion

        #region Constructors

        internal TogglWorkspacesEndpoint(TogglService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
        /// </see>
        public TogglProjectListResponse GetProjects(int workspaceId) {
            return TogglProjectListResponse.Parse(Raw.GetProjects(workspaceId));
        }

        /// <summary>
        /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <param name="active">The active state that the returned projects should match.</param>
        /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
        /// </see>
        public TogglProjectListResponse GetProjects(int workspaceId, TogglProjectActiveState active) {
            return TogglProjectListResponse.Parse(Raw.GetProjects(workspaceId, active));
        }

        /// <summary>
        /// Gets a list of projects matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
        /// </see>
        public TogglProjectListResponse GetProjects(TogglGetProjectsOptions options) {
            return TogglProjectListResponse.Parse(Raw.GetProjects(options));
        }

        #endregion

    }

}
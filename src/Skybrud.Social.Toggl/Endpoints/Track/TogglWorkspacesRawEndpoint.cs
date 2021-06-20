using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Track.Projects;
using Skybrud.Social.Toggl.Options.Track.Workspaces;

namespace Skybrud.Social.Toggl.Endpoints.Track {

    /// <summary>
    /// Raw implementation of the <strong>Workspaces</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md</cref>
    /// </see>
    public class TogglWorkspacesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the HTTP client.
        /// </summary>
        public TogglHttpClient Client { get; }

        #endregion

        #region Constructors

        internal TogglWorkspacesRawEndpoint(TogglHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of workspaces the owner of the access token belongs to.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspaces</cref>
        /// </see>
        public IHttpResponse GetWorkspaces() {
            return Client.Get("/api/v8/workspaces");
        }

        /// <summary>
        /// Gets information about the workspace with the specified <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-single-workspace</cref>
        /// </see>
        public IHttpResponse GetWorkspace(int workspaceId) {
            return Client.Get($"/api/v8/workspaces/{workspaceId}");
        }

        /// <summary>
        /// Gets a list of all workspace clients.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-clients</cref>
        /// </see>
        public IHttpResponse GetClients(int workspaceId) {
            return Client.Get($"/api/v8/workspaces/{workspaceId}/clients");
        }

        /// <summary>
        /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
        /// </see>
        public IHttpResponse GetProjects(int workspaceId) {
            return Client.GetResponse(new TogglGetProjectsOptions(workspaceId));
        }

        /// <summary>
        /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <param name="active">The active state that the returned projects should match.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
        /// </see>
        public IHttpResponse GetProjects(int workspaceId, TogglProjectActiveState active) {
            return Client.GetResponse(new TogglGetProjectsOptions(workspaceId, active));
        }

        /// <summary>
        /// Gets a list of projects matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
        /// </see>
        public IHttpResponse GetProjects(TogglGetProjectsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a list of tags of the workspace.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-tags</cref>
        /// </see>
        public IHttpResponse GetTags(int workspaceId) {
            return Client.Get($"/api/v8/workspaces/{workspaceId}/tags");
        }

        #endregion

    }

}
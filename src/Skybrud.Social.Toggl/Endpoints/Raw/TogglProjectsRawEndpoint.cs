using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Projects;

namespace Skybrud.Social.Toggl.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Projects</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md</cref>
    /// </see>
    public class TogglProjectsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the HTTP client.
        /// </summary>
        public TogglHttpClient Client { get; }

        #endregion

        #region Constructors

        internal TogglProjectsRawEndpoint(TogglHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Creates a new project with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the project to be created</param>
        /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#create-project</cref>
        /// </see>
        public IHttpResponse CreateProject(string name, int workspaceId) {
            return Client.Post(new TogglCreateProjectsOptions(name, workspaceId));
        }

        /// <summary>
        /// Creates a new project with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the project to be created</param>
        /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
        /// <param name="clientId">The ID of the parent client.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#create-project</cref>
        /// </see>
        public IHttpResponse CreateProject(string name, int workspaceId, int clientId) {
            return Client.Post(new TogglCreateProjectsOptions(name, workspaceId, clientId));
        }

        /// <summary>
        /// Creates a new project based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        public IHttpResponse CreateProject(TogglCreateProjectsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.Post(options);
        }

        /// <summary>
        /// Updates the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        public IHttpResponse UpdateProject(TogglUpdateProjectOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}
using System;
using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;
using Skybrud.Social.Toggl.Options.Track.Projects;

namespace Skybrud.Social.Toggl.Endpoints.Track {

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
            return Client.GetResponse(new TogglCreateProjectsOptions(name, workspaceId));
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
            return Client.GetResponse(new TogglCreateProjectsOptions(name, workspaceId, clientId));
        }

        /// <summary>
        /// Creates a new project based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        public IHttpResponse CreateProject(TogglCreateProjectsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets information about the project with the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#get-project-data</cref>
        /// </see>
        public IHttpResponse GetProject(int projectId) {
            return Client.GetResponse(new TogglGetProjectOptions(projectId));
        }

        /// <summary>
        /// Gets information about the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#get-project-data</cref>
        /// </see>
        public IHttpResponse GetProject(TogglGetProjectOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Updates the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#update-project-data</cref>
        /// </see>
        public IHttpResponse UpdateProject(TogglUpdateProjectOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Deletes the project with the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project</cref>
        /// </see>
        public IHttpResponse DeleteProject(int projectId) {
            return Client.GetResponse(new TogglDeleteProjectOptions(projectId));
        }

        /// <summary>
        /// Deletes the specified <paramref name="project"/>.
        /// </summary>
        /// <param name="project">The project to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project</cref>
        /// </see>
        public IHttpResponse DeleteProject(TogglProject project) {
            if (project == null) throw new ArgumentNullException(nameof(project));
            return Client.GetResponse(new TogglDeleteProjectOptions(project));
        }

        /// <summary>
        /// Deletes the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project</cref>
        /// </see>
        public IHttpResponse DeleteProject(TogglDeleteProjectOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Deletes the projects with the specified <paramref name="projectIds"/>.
        /// </summary>
        /// <param name="projectIds">The IDs of the projects to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public IHttpResponse DeleteProjects(params int[] projectIds) {
            return Client.GetResponse(new TogglDeleteProjectsOptions(projectIds));
        }

        /// <summary>
        /// Deletes the projects with the specified <paramref name="projectIds"/>.
        /// </summary>
        /// <param name="projectIds">The IDs of the projects to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public IHttpResponse DeleteProjects(IEnumerable<int> projectIds) {
            return Client.GetResponse(new TogglDeleteProjectsOptions(projectIds));
        }

        /// <summary>
        /// Deletes the specified <paramref name="projects"/>.
        /// </summary>
        /// <param name="projects">The projects to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public IHttpResponse DeleteProjects(params TogglProject[] projects) {
            if (projects == null) throw new ArgumentNullException(nameof(projects));
            return Client.GetResponse(new TogglDeleteProjectsOptions(projects));
        }

        /// <summary>
        /// Deletes the specified <paramref name="projects"/>.
        /// </summary>
        /// <param name="projects">The projects to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public IHttpResponse DeleteProjects(IEnumerable<TogglProject> projects) {
            if (projects == null) throw new ArgumentNullException(nameof(projects));
            return Client.GetResponse(new TogglDeleteProjectsOptions(projects));
        }

        #endregion

    }

}
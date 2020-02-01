using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Endpoints.Raw;
using Skybrud.Social.Toggl.Models.Projects;
using Skybrud.Social.Toggl.Options.Projects;
using Skybrud.Social.Toggl.Responses;
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
        /// Gets information about the project with the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#get-project-data</cref>
        /// </see>
        public TogglProjectResponse GetProject(int projectId) {
            return new TogglProjectResponse(Raw.GetProject(projectId));
        }

        /// <summary>
        /// Gets information about the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#get-project-data</cref>
        /// </see>
        public TogglProjectResponse GetProject(TogglGetProjectOptions options) {
            return new TogglProjectResponse(Raw.GetProject(options));
        }

        /// <summary>
        /// Updates the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#update-project-data</cref>
        /// </see>
        public TogglProjectResponse UpdateProject(TogglUpdateProjectOptions options) {
            return TogglProjectResponse.Parse(Raw.UpdateProject(options));
        }

        /// <summary>
        /// Deletes the project with the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project to be deleted.</param>
        /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project</cref>
        /// </see>
        public TogglResponse DeleteProject(int projectId) {
            return new TogglResponse(Raw.DeleteProject(projectId));
        }

        /// <summary>
        /// Deletes the specified <paramref name="project"/>.
        /// </summary>
        /// <param name="project">The project to be deleted.</param>
        /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project</cref>
        /// </see>
        public TogglResponse DeleteProject(TogglProject project) {
            return new TogglResponse(Raw.DeleteProject(project));
        }

        /// <summary>
        /// Deletes the project matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project</cref>
        /// </see>
        public TogglResponse DeleteProject(TogglDeleteProjectOptions options) {
            return new TogglResponse(Raw.DeleteProject(options));
        }

        /// <summary>
        /// Deletes the projects with the specified <paramref name="projectIds"/>.
        /// </summary>
        /// <param name="projectIds">The IDs of the projects to be deleted.</param>
        /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public TogglResponse DeleteProjects(params int[] projectIds) {
            return new TogglResponse(Raw.DeleteProjects(projectIds));
        }

        /// <summary>
        /// Deletes the projects with the specified <paramref name="projectIds"/>.
        /// </summary>
        /// <param name="projectIds">The IDs of the projects to be deleted.</param>
        /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public TogglResponse DeleteProjects(IEnumerable<int> projectIds) {
            return new TogglResponse(Raw.DeleteProjects(projectIds));
        }

        /// <summary>
        /// Deletes the specified <paramref name="projects"/>.
        /// </summary>
        /// <param name="projects">The projects to be deleted.</param>
        /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public TogglResponse DeleteProjects(params TogglProject[] projects) {
            return new TogglResponse(Raw.DeleteProjects(projects));
        }

        /// <summary>
        /// Deletes the specified <paramref name="projects"/>.
        /// </summary>
        /// <param name="projects">The projects to be deleted.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-multiple-projects</cref>
        /// </see>
        public TogglResponse DeleteProjects(IEnumerable<TogglProject> projects) {
            return new TogglResponse(Raw.DeleteProjects(projects));
        }

        #endregion

    }

}
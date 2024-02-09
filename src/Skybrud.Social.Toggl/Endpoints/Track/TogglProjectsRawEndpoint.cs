using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;
using Skybrud.Social.Toggl.Options.Track.Projects;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Raw implementation of the <strong>Projects</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/projects</cref>
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

    #region GetProjects(...)

    /// <summary>
    /// Returns a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public IHttpResponse GetProjects(int workspaceId) {
        return Client.GetResponse(new TogglGetProjectsOptions(workspaceId));
    }

    /// <summary>
    /// Returns a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="active">The active state that the returned projects should match.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public IHttpResponse GetProjects(int workspaceId, bool? active) {
        return Client.GetResponse(new TogglGetProjectsOptions(workspaceId, active));
    }

    /// <summary>
    /// Returns a list of projects matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public IHttpResponse GetProjects(TogglGetProjectsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region GetProjectsAsync(...)

    /// <summary>
    /// Returns a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> GetProjectsAsync(int workspaceId) {
        return await Client.GetResponseAsync(new TogglGetProjectsOptions(workspaceId));
    }

    /// <summary>
    /// Returns a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="active">The active state that the returned projects should match.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> GetProjectsAsync(int workspaceId, bool? active) {
        return await Client.GetResponseAsync(new TogglGetProjectsOptions(workspaceId, active));
    }

    /// <summary>
    /// Returns a list of projects matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> GetProjectsAsync(TogglGetProjectsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region CreateProject(...)

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public IHttpResponse CreateProject(int workspaceId, string name) {
        return CreateProject(new TogglCreateProjectOptions(workspaceId, name));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <param name="active">Whether the created project should be active. If not set to <see langword="true"/>, the project will be created as archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public IHttpResponse CreateProject(int workspaceId, string name, bool? active) {
        return CreateProject(new TogglCreateProjectOptions(workspaceId, name, active));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="clientId">The ID of the parent client.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public IHttpResponse CreateProject(int workspaceId, int? clientId, string name) {
        return CreateProject(new TogglCreateProjectOptions(workspaceId, clientId, name));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="clientId">The ID of the parent client.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <param name="active">Whether the created project should be active. If not set to <see langword="true"/>, the project will be created as archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public IHttpResponse CreateProject(int workspaceId, int? clientId, string name, bool? active) {
        return CreateProject(new TogglCreateProjectOptions(workspaceId, clientId, name, active));
    }

    /// <summary>
    /// Creates a new project based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public IHttpResponse CreateProject(TogglCreateProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region CreateProjectAsync(...)

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> CreateProjectAsync(int workspaceId, string name) {
        return await CreateProjectAsync(new TogglCreateProjectOptions(workspaceId, name));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <param name="active">Whether the created project should be active. If not set to <see langword="true"/>, the project will be created as archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> CreateProjectAsync(int workspaceId, string name, bool? active) {
        return await CreateProjectAsync(new TogglCreateProjectOptions(workspaceId, name, active));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="clientId">The ID of the parent client.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> CreateProjectAsync(int workspaceId, int? clientId, string name) {
        return await CreateProjectAsync(new TogglCreateProjectOptions(workspaceId, clientId, name));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="clientId">The ID of the parent client.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <param name="active">Whether the created project should be active. If not set to <see langword="true"/>, the project will be created as archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> CreateProjectAsync(int workspaceId, int? clientId, string name, bool? active) {
        return await CreateProjectAsync(new TogglCreateProjectOptions(workspaceId, clientId, name, active));
    }

    /// <summary>
    /// Creates a new project based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<IHttpResponse> CreateProjectAsync(TogglCreateProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region GetProject(...)

    /// <summary>
    /// Gets information about the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public IHttpResponse GetProject(int workspaceId, int projectId) {
        return Client.GetResponse(new TogglGetProjectOptions(workspaceId, projectId));
    }

    /// <summary>
    /// Gets information about the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public IHttpResponse GetProject(TogglGetProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region GetProjectAsync(...)

    /// <summary>
    /// Gets information about the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public async Task<IHttpResponse> GetProjectAsync(int workspaceId, int projectId) {
        return await Client.GetResponseAsync(new TogglGetProjectOptions(workspaceId, projectId));
    }

    /// <summary>
    /// Gets information about the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public async Task<IHttpResponse> GetProjectAsync(TogglGetProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region UpdateProject(...)

    /// <summary>
    /// Updates the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#put-workspaceproject</cref>
    /// </see>
    public IHttpResponse UpdateProject(TogglUpdateProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region UpdateProjectAsync(...)

    /// <summary>
    /// Updates the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#put-workspaceproject</cref>
    /// </see>
    public async Task<IHttpResponse> UpdateProjectAsync(TogglUpdateProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region DeleteProject(...)

    /// <summary>
    /// Deletes the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project to be deleted.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public IHttpResponse DeleteProject(int workspaceId, int projectId) {
        return Client.GetResponse(new TogglDeleteProjectOptions(workspaceId, projectId));
    }

    /// <summary>
    /// Deletes the specified <paramref name="project"/>.
    /// </summary>
    /// <param name="project">The project to be deleted.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
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
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public IHttpResponse DeleteProject(TogglDeleteProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region DeleteProjectAsync(...)

    /// <summary>
    /// Deletes the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project to be deleted.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public async Task<IHttpResponse> DeleteProjectAsync(int workspaceId, int projectId) {
        return await Client.GetResponseAsync(new TogglDeleteProjectOptions(workspaceId, projectId));
    }

    /// <summary>
    /// Deletes the specified <paramref name="project"/>.
    /// </summary>
    /// <param name="project">The project to be deleted.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public async Task<IHttpResponse> DeleteProjectAsync(TogglProject project) {
        if (project == null) throw new ArgumentNullException(nameof(project));
        return await Client.GetResponseAsync(new TogglDeleteProjectOptions(project));
    }

    /// <summary>
    /// Deletes the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public async Task<IHttpResponse> DeleteProjectAsync(TogglDeleteProjectOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #endregion

}
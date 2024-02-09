using System.Threading.Tasks;
using Skybrud.Social.Toggl.Models.Track.Projects;
using Skybrud.Social.Toggl.Options.Track.Projects;
using Skybrud.Social.Toggl.Responses;
using Skybrud.Social.Toggl.Responses.Track.Projects;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the <strong>Projects</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/projects</cref>
/// </see>
public class TogglProjectsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglProjectsRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    internal TogglProjectsEndpoint(TogglHttpService service) {
        Service = service;
        Raw = service.Client.Track.Projects;
    }

    #endregion

    #region Member methods

    #region GetProjects(...)

    /// <summary>
    /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public TogglProjectListResponse GetProjects(int workspaceId) {
        return new TogglProjectListResponse(Raw.GetProjects(workspaceId));
    }

    /// <summary>
    /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="active">The active state that the returned projects should match.</param>
    /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public TogglProjectListResponse GetProjects(int workspaceId, bool? active) {
        return new TogglProjectListResponse(Raw.GetProjects(workspaceId, active));
    }

    /// <summary>
    /// Gets a list of projects matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public TogglProjectListResponse GetProjects(TogglGetProjectsOptions options) {
        return new TogglProjectListResponse(Raw.GetProjects(options));
    }

    #endregion

    #region GetProjectsAsync(...)

    /// <summary>
    /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public async Task<TogglProjectListResponse> GetProjectsAsync(int workspaceId) {
        return new TogglProjectListResponse(await Raw.GetProjectsAsync(workspaceId));
    }

    /// <summary>
    /// Gets a list of projects of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="active">The active state that the returned projects should match.</param>
    /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public async Task<TogglProjectListResponse> GetProjectsAsync(int workspaceId, bool? active) {
        return new TogglProjectListResponse(await Raw.GetProjectsAsync(workspaceId, active));
    }

    /// <summary>
    /// Gets a list of projects matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
    /// </see>
    public async Task<TogglProjectListResponse> GetProjectsAsync(TogglGetProjectsOptions options) {
        return new TogglProjectListResponse(await Raw.GetProjectsAsync(options));
    }

    #endregion

    #region CreateProject(...)

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public TogglProjectResponse CreateProject(int workspaceId, string name) {
        return new TogglProjectResponse(Raw.CreateProject(workspaceId, name));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="clientId">The ID of the parent client.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public TogglProjectResponse CreateProject(int workspaceId, int clientId, string name) {
        return new TogglProjectResponse(Raw.CreateProject(workspaceId, clientId, name));
    }

    /// <summary>
    /// Creates a new project based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public TogglProjectResponse CreateProject(TogglCreateProjectOptions options) {
        return new TogglProjectResponse(Raw.CreateProject(options));
    }

    #endregion

    #region CreateProjectAsync(...)

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<TogglProjectResponse> CreateProjectAsync(int workspaceId, string name) {
        return new TogglProjectResponse(await Raw.CreateProjectAsync(workspaceId, name));
    }

    /// <summary>
    /// Creates a new project with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to which the project should be added.</param>
    /// <param name="clientId">The ID of the parent client.</param>
    /// <param name="name">The name of the project to be created</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<TogglProjectResponse> CreateProjectAsync(int workspaceId, int clientId, string name) {
        return new TogglProjectResponse(await Raw.CreateProjectAsync(workspaceId, clientId, name));
    }

    /// <summary>
    /// Creates a new project based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#post-workspaceprojects</cref>
    /// </see>
    public async Task<TogglProjectResponse> CreateProjectAsync(TogglCreateProjectOptions options) {
        return new TogglProjectResponse(await Raw.CreateProjectAsync(options));
    }

    #endregion

    #region GetProject(...)

    /// <summary>
    /// Gets information about the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public TogglProjectResponse GetProject(int workspaceId, int projectId) {
        return new TogglProjectResponse(Raw.GetProject(workspaceId, projectId));
    }

    /// <summary>
    /// Gets information about the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public TogglProjectResponse GetProject(TogglGetProjectOptions options) {
        return new TogglProjectResponse(Raw.GetProject(options));
    }

    #endregion

    #region GetProjectAsync(...)

    /// <summary>
    /// Gets information about the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public async Task<TogglProjectResponse> GetProjectAsync(int workspaceId, int projectId) {
        return new TogglProjectResponse(await Raw.GetProjectAsync(workspaceId, projectId));
    }

    /// <summary>
    /// Gets information about the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
    /// </see>
    public async Task<TogglProjectResponse> GetProjectAsync(TogglGetProjectOptions options) {
        return new TogglProjectResponse(await Raw.GetProjectAsync(options));
    }

    #endregion

    #region UpdateProject(...)

    /// <summary>
    /// Updates the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#put-workspaceproject</cref>
    /// </see>
    public TogglProjectResponse UpdateProject(TogglUpdateProjectOptions options) {
        return new TogglProjectResponse(Raw.UpdateProject(options));
    }

    #endregion

    #region UpdateProjectAsync(...)

    /// <summary>
    /// Updates the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#put-workspaceproject</cref>
    /// </see>
    public async Task<TogglProjectResponse> UpdateProjectAsync(TogglUpdateProjectOptions options) {
        return new TogglProjectResponse(await Raw.UpdateProjectAsync(options));
    }

    #endregion

    #region DeleteProject

    /// <summary>
    /// Deletes the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project to be deleted.</param>
    /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public TogglResponse DeleteProject(int workspaceId, int projectId) {
        return new TogglResponse(Raw.DeleteProject(workspaceId, projectId));
    }

    /// <summary>
    /// Deletes the specified <paramref name="project"/>.
    /// </summary>
    /// <param name="project">The project to be deleted.</param>
    /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
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
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public TogglResponse DeleteProject(TogglDeleteProjectOptions options) {
        return new TogglResponse(Raw.DeleteProject(options));
    }

    #endregion

    #region DeleteProjectAsync

    /// <summary>
    /// Deletes the project with the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project to be deleted.</param>
    /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public async Task<TogglResponse> DeleteProjectAsync(int workspaceId, int projectId) {
        return new TogglResponse(await Raw.DeleteProjectAsync(workspaceId, projectId));
    }

    /// <summary>
    /// Deletes the specified <paramref name="project"/>.
    /// </summary>
    /// <param name="project">The project to be deleted.</param>
    /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public async Task<TogglResponse> DeleteProjectAsync(TogglProject project) {
        return new TogglResponse(await Raw.DeleteProjectAsync(project));
    }

    /// <summary>
    /// Deletes the project matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
    /// </see>
    public async Task<TogglResponse> DeleteProjectAsync(TogglDeleteProjectOptions options) {
        return new TogglResponse(await Raw.DeleteProjectAsync(options));
    }

    #endregion

    #endregion

}
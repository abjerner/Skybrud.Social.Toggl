using Skybrud.Essentials.Http;
using System.Threading.Tasks;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Options.Track.User;
using Skybrud.Social.Toggl.Responses.Track.Clients;
using Skybrud.Social.Toggl.Responses.Track.Projects;
using Skybrud.Social.Toggl.Responses.Track.User;
using Skybrud.Social.Toggl.Responses.Track.Workspaces;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the <strong>User</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/me</cref>
/// </see>
public class TogglUserEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglUserRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    internal TogglUserEndpoint(TogglHttpService service) {
        Service = service;
        Raw = service.Client.Track.User;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/me#get-me</cref>
    /// </see>
    public TogglUserResponse GetUser() {
        return new TogglUserResponse(Raw.GetUser());
    }

    /// <summary>
    /// Returns information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/me#get-me</cref>
    /// </see>
    public async Task<TogglUserResponse> GetUserAsync() {
        return new TogglUserResponse(await Raw.GetUserAsync());
    }

    /// <summary>
    /// Returns the preferences of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="TogglUserPreferencesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/preferences#get-preferences-for-the-current-user</cref>
    /// </see>
    public TogglUserPreferencesResponse GetPreferences() {
        return new TogglUserPreferencesResponse(Raw.GetPreferences());
    }

    /// <summary>
    /// Returns the preferences of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="TogglUserPreferencesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/preferences#get-preferences-for-the-current-user</cref>
    /// </see>
    public async Task<TogglUserPreferencesResponse> GetPreferencesAsync() {
        return new TogglUserPreferencesResponse(await Raw.GetPreferencesAsync());
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user created, modified or deleted since the specified timestamp.
    /// </summary>
    /// <param name="since">Only clients created, modified or deleted since this timestamp will be returned</param>
    /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public TogglClientListResponse GetClients(EssentialsTime since) {
        return new TogglClientListResponse(Raw.GetClients(since));
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public TogglClientListResponse GetClients(TogglGetClientsOptions options) {
        return new TogglClientListResponse(Raw.GetClients(options));
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public async Task<TogglClientListResponse> GetClientsAsync() {
        return new TogglClientListResponse(await Raw.GetClientsAsync());
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user created, modified or deleted since the specified timestamp.
    /// </summary>
    /// <param name="since">Only clients created, modified or deleted since this timestamp will be returned</param>
    /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public async Task<TogglClientListResponse> GetClientsAsync(EssentialsTime since) {
        return new TogglClientListResponse(await Raw.GetClientsAsync(since));
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public async Task<TogglClientListResponse> GetClientsAsync(TogglGetClientsOptions options) {
        return new TogglClientListResponse(await Raw.GetClientsAsync(options));
    }

    /// <summary>
    /// Returns a list of all Toggl Track features.
    /// </summary>
    /// <returns>An instance of <see cref="TogglUserFeaturesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-features</cref>
    /// </see>
    public TogglUserFeaturesResponse GetFeatures() {
        return new TogglUserFeaturesResponse(Raw.GetFeatures());
    }

    /// <summary>
    /// Returns a list of all Toggl Track features.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglUserFeaturesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-features</cref>
    /// </see>
    public TogglUserFeaturesResponse GetFeatures(TogglGetFeaturesOptions options) {
        return new TogglUserFeaturesResponse(Raw.GetFeatures(options));
    }

    /// <summary>
    /// Returns a list of all Toggl Track features.
    /// </summary>
    /// <returns>An instance of <see cref="TogglUserFeaturesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-features</cref>
    /// </see>
    public async Task<TogglUserFeaturesResponse> GetFeaturesAsync() {
        return new TogglUserFeaturesResponse(await Raw.GetFeaturesAsync());
    }

    /// <summary>
    /// Returns a list of all Toggl Track features.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglUserFeaturesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-features</cref>
    /// </see>
    public async Task<TogglUserFeaturesResponse> GetFeaturesAsync(TogglGetFeaturesOptions options) {
        return new TogglUserFeaturesResponse(await Raw.GetFeaturesAsync(options));
    }

    /// <summary>
    /// Returns a list with all non-archived projects of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-projects</cref>
    /// </see>
    public TogglProjectListResponse GetProjects() {
        return new TogglProjectListResponse(Raw.GetProjects());
    }

    /// <summary>
    /// Returns a list with all non-archived projects of the authenticated user.
    /// </summary>
    /// <param name="includeArchived">Whether archived projects should be included in the list.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-projects</cref>
    /// </see>
    public TogglProjectListResponse GetProjects(bool includeArchived) {
        return new TogglProjectListResponse(Raw.GetProjects(includeArchived));
    }

    /// <summary>
    /// Returns a list with all projects of the authenticated user matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-projects</cref>
    /// </see>
    public TogglProjectListResponse GetProjects(TogglGetProjectsOptions options) {
        return new TogglProjectListResponse(Raw.GetProjects(options));
    }

    /// <summary>
    /// Returns a list with all non-archived projects of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-projects</cref>
    /// </see>
    public async Task<TogglProjectListResponse> GetProjectsAsync() {
        return new TogglProjectListResponse(await Raw.GetProjectsAsync());
    }

    /// <summary>
    /// Returns a list with all non-archived projects of the authenticated user.
    /// </summary>
    /// <param name="includeArchived">Whether archived projects should be included in the list.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-projects</cref>
    /// </see>
    public async Task<TogglProjectListResponse> GetProjectsAsync(bool includeArchived) {
        return new TogglProjectListResponse(await Raw.GetProjectsAsync(includeArchived));
    }

    /// <summary>
    /// Returns a list with all projects of the authenticated user matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-projects</cref>
    /// </see>
    public async Task<TogglProjectListResponse> GetProjectsAsync(TogglGetProjectsOptions options) {
        return new TogglProjectListResponse(await Raw.GetProjectsAsync(options));
    }

    /// <summary>
    /// Returns all workspaced the authenticated user is a part of.
    /// </summary>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-workspaces</cref>
    /// </see>
    public TogglWorkspaceListResponse GetWorkspaces() {
        return new TogglWorkspaceListResponse(Raw.GetWorkspaces());
    }

    /// <summary>
    /// Returns all workspaces the authenticated user is a part of.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-workspaces</cref>
    /// </see>
    public TogglWorkspaceListResponse GetWorkspaces(TogglGetWorkspacesOptions options) {
        return new TogglWorkspaceListResponse(Raw.GetWorkspaces(options));
    }

    /// <summary>
    /// Returns all workspaces the authenticated user is a part of.
    /// </summary>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-workspaces</cref>
    /// </see>
    public async Task<TogglWorkspaceListResponse> GetWorkspacesAsync() {
        return new TogglWorkspaceListResponse(await Raw.GetWorkspacesAsync());
    }

    /// <summary>
    /// Returns all workspaces the authenticated user is a part of.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-workspaces</cref>
    /// </see>
    public async Task<TogglWorkspaceListResponse> GetWorkspacesAsync(TogglGetWorkspacesOptions options) {
        return new TogglWorkspaceListResponse(await Raw.GetWorkspacesAsync(options));
    }

    #endregion

}
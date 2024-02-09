using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Track.Workspaces;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Raw implementation of the <strong>Workspaces</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/workspaces</cref>
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

    #region GetWorkspaces(...)

    /// <summary>
    /// Gets a list of workspaces of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    public IHttpResponse GetWorkspaces() {
        return GetWorkspaces(new TogglGetWorkspacesOptions());
    }

    /// <summary>
    /// Gets a list of workspaces of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    public IHttpResponse GetWorkspaces(TogglGetWorkspacesOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region GetWorkspacesAsync(...)

    /// <summary>
    /// Gets a list of workspaces of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    public async Task<IHttpResponse> GetWorkspacesAsync() {
        return await GetWorkspacesAsync(new TogglGetWorkspacesOptions());
    }

    /// <summary>
    /// Gets a list of workspaces of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    public async Task<IHttpResponse> GetWorkspacesAsync(TogglGetWorkspacesOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region GetWorkspace(...)

    /// <summary>
    /// Gets information about the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public IHttpResponse GetWorkspace(int workspaceId) {
        return GetWorkspace(new TogglGetWorkspaceOptions(workspaceId));
    }

    /// <summary>
    /// Gets information about the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public IHttpResponse GetWorkspace(TogglGetWorkspaceOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region GetWorkspaceAsync(...)

    /// <summary>
    /// Gets information about the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public async Task<IHttpResponse> GetWorkspaceAsync(int workspaceId) {
        return await GetWorkspaceAsync(new TogglGetWorkspaceOptions(workspaceId));
    }

    /// <summary>
    /// Gets information about the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public async Task<IHttpResponse> GetWorkspaceAsync(TogglGetWorkspaceOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #endregion

}
using System.Threading.Tasks;
using Skybrud.Social.Toggl.Options.Track.Workspaces;
using Skybrud.Social.Toggl.Responses.Track.Workspaces;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the <strong>Workspaces</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/workspaces</cref>
/// </see>
public class TogglWorkspacesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglWorkspacesRawEndpoint Raw => Service.Client.Track.Workspaces;

    #endregion

    #region Constructors

    internal TogglWorkspacesEndpoint(TogglHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    #region GetWorkspaces(...)

    /// <summary>
    /// Gets a list of workspaces the owner of the access token belongs to.
    /// </summary>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <remarks>This method is not mentioned by the Toggl Track API documentation.</remarks>
    public TogglWorkspaceListResponse GetWorkspaces() {
        return new TogglWorkspaceListResponse(Raw.GetWorkspaces());
    }

    /// <summary>
    /// Gets a list of workspaces of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <remarks>This method is not mentioned by the Toggl Track API documentation.</remarks>
    public TogglWorkspaceListResponse GetWorkspaces(TogglGetWorkspacesOptions options) {
        return new TogglWorkspaceListResponse(Raw.GetWorkspaces(options));
    }

    #endregion

    #region GetWorkspacesAsync(...)

    /// <summary>
    /// Gets a list of workspaces the owner of the access token belongs to.
    /// </summary>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <remarks>This method is not mentioned by the Toggl Track API documentation.</remarks>
    public async Task<TogglWorkspaceListResponse> GetWorkspacesAsync() {
        return new TogglWorkspaceListResponse(await Raw.GetWorkspacesAsync());
    }

    /// <summary>
    /// Gets a list of workspaces of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response from the Toggl API.</returns>
    /// <remarks>This method is not mentioned by the Toggl Track API documentation.</remarks>
    public async Task<TogglWorkspaceListResponse> GetWorkspacesAsync(TogglGetWorkspacesOptions options) {
        return new TogglWorkspaceListResponse(await Raw.GetWorkspacesAsync(options));
    }

    #endregion

    #region GetWorkspace(...)

    /// <summary>
    /// Gets information about the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public TogglWorkspaceResponse GetWorkspace(int workspaceId) {
        return new TogglWorkspaceResponse(Raw.GetWorkspace(workspaceId));
    }

    /// <summary>
    /// Gets information about the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public TogglWorkspaceResponse GetWorkspace(TogglGetWorkspaceOptions options) {
        return new TogglWorkspaceResponse(Raw.GetWorkspace(options));
    }

    #endregion

    #region GetWorkspaceAsync(...)

    /// <summary>
    /// Gets information about the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public async Task<TogglWorkspaceResponse> GetWorkspaceAsync(int workspaceId) {
        return new TogglWorkspaceResponse(await Raw.GetWorkspaceAsync(workspaceId));
    }

    /// <summary>
    /// Gets information about the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/workspaces#get-get-single-workspace</cref>
    /// </see>
    public async Task<TogglWorkspaceResponse> GetWorkspaceAsync(TogglGetWorkspaceOptions options) {
        return new TogglWorkspaceResponse(await Raw.GetWorkspaceAsync(options));
    }

    #endregion

    #endregion

}
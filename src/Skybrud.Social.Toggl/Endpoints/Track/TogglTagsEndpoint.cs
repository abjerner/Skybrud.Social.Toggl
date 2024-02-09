using System.Threading.Tasks;
using Skybrud.Social.Toggl.Options.Track.Tags;
using Skybrud.Social.Toggl.Responses.Track.Tag;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the raw <strong>Tags</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/tags</cref>
/// </see>
public class TogglTagsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglTagsRawEndpoint Raw => Service.Client.Track.Tags;

    #endregion

    #region Constructors

    internal TogglTagsEndpoint(TogglHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a list of all tags of the workspace with the specified <paramref name="workspaceId."/>
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="TogglTagListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public TogglTagListResponse GetTags(int workspaceId) {
        return new TogglTagListResponse(Raw.GetTags(workspaceId));
    }

    /// <summary>
    /// Returns a list of all tags of the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglTagListResponse"/> representing raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public TogglTagListResponse GetTags(TogglGetTagsOptions options) {
        return new TogglTagListResponse(Raw.GetTags(options));
    }

    /// <summary>
    /// Returns a list of all tags of the workspace with the specified <paramref name="workspaceId."/>
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="TogglTagListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public async Task<TogglTagListResponse> GetTagsAsync(int workspaceId) {
        return new TogglTagListResponse(await Raw.GetTagsAsync(workspaceId));
    }

    /// <summary>
    /// Returns a list of all tags of the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglTagListResponse"/> representing raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public async Task<TogglTagListResponse> GetTagsAsync(TogglGetTagsOptions options) {
        return new TogglTagListResponse(await Raw.GetTagsAsync(options));
    }

    #endregion

}
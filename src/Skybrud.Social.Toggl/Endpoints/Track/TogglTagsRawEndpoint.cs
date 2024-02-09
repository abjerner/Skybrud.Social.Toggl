using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Track.Tags;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Raw implementation of the <strong>Tags</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/tags</cref>
/// </see>
public class TogglTagsRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the HTTP client.
    /// </summary>
    public TogglHttpClient Client { get; }

    #endregion

    #region Constructors

    internal TogglTagsRawEndpoint(TogglHttpClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a list of all tags of the workspace with the specified <paramref name="workspaceId."/>
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public IHttpResponse GetTags(int workspaceId) {
        return GetTags(new TogglGetTagsOptions(workspaceId));
    }

    /// <summary>
    /// Returns a list of all tags of the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public IHttpResponse GetTags(TogglGetTagsOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns a list of all tags of the workspace with the specified <paramref name="workspaceId."/>
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public async Task<IHttpResponse> GetTagsAsync(int workspaceId) {
        return await GetTagsAsync(new TogglGetTagsOptions(workspaceId));
    }

    /// <summary>
    /// Returns a list of all tags of the workspace identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
    /// </see>
    public async Task<IHttpResponse> GetTagsAsync(TogglGetTagsOptions options) {
        if (options is null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}
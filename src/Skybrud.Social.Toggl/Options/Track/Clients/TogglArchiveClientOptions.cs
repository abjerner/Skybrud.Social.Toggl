using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Options.Track.Clients;

/// <summary>
/// Options describing a request tfor archiving a Toggl client.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients#post-archives-client</cref>
/// </see>
public class TogglArchiveClientOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the parent workspace.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int WorkspaceId { get; set; }
#else
    public int WorkspaceId { get; set; }
#endif

    /// <summary>
    /// Gets or sets the ID of the client.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int ClientId { get; set; }
#else
    public int ClientId { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglArchiveClientOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public TogglArchiveClientOptions(int workspaceId, int clientId) {
        WorkspaceId = workspaceId;
        ClientId = clientId;
    }

    /// <summary>
    /// Initialize a new instance based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The Toggl client to be archived.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public TogglArchiveClientOptions(TogglClient client) {
        WorkspaceId = client.WorkspaceId;
        ClientId = client.Id;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        if (ClientId == 0) throw new PropertyNotSetException(nameof(ClientId));
        return HttpRequest.Post($"/api/v9/workspaces/{WorkspaceId}/clients/{ClientId}/archive");
    }

    #endregion

}
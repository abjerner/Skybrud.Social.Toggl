using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Options.Track.Clients;

/// <summary>
/// Options for a request to delete a Toggl client.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients#delete-delete-client</cref>
/// </see>
public class TogglDeleteClientOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the parent workspace.
    /// </summary>
    public int WorkspaceId { get; }

    /// <summary>
    /// Gets or sets the ID of the client.
    /// </summary>
    public int ClientId { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
    public TogglDeleteClientOptions(int workspaceId, int clientId) {
        WorkspaceId = workspaceId;
        ClientId = clientId;
    }

    /// <summary>
    /// Initialize a new instance based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The Toggl client to be deleted.</param>
    public TogglDeleteClientOptions(TogglClient client) {
        WorkspaceId = client.WorkspaceId;
        ClientId = client.Id;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        if (ClientId == 0) throw new PropertyNotSetException(nameof(ClientId));
        return HttpRequest.Delete($"/api/v9/workspaces/{WorkspaceId}/clients/{ClientId}");
    }

    #endregion

}
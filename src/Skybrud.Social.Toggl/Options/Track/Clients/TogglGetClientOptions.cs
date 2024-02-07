using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Clients;

/// <summary>
/// Options for a request to get information about a single Toggl client.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients#get-load-client-from-id</cref>
/// </see>
public class TogglGetClientOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the parent workspace.
    /// </summary>
    public int WorkspaceId { get; }

    /// <summary>
    /// Gets or sets the ID of the client.
    /// </summary>
    public int Id { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
    public TogglGetClientOptions(int workspaceId, int clientId) {
        WorkspaceId = workspaceId;
        Id = clientId;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        if (Id == 0) throw new PropertyNotSetException(nameof(Id));
        return HttpRequest.Get($"/api/v9/workspaces/{WorkspaceId}/clients/{Id}");
    }

    #endregion

}
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Clients;

/// <summary>
/// Options for a request to getting all Toggl clients in a workspace.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients#get-list-clients</cref>
/// </see>
public class TogglGetClientsOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the workspace.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int WorkspaceId { get; set; }
#else
    public int WorkspaceId { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglGetClientsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public TogglGetClientsOptions(int workspaceId) {
        WorkspaceId = workspaceId;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
        return HttpRequest.Get($"/api/v9/workspaces/{WorkspaceId}/clients");
    }

    #endregion

}
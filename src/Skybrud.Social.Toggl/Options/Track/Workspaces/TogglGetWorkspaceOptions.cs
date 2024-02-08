using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Workspaces;

/// <summary>
/// Options describing a request for getting a Toggl workspace.
/// </summary>
public class TogglGetWorkspaceOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the workspace.
    /// </summary>
    public int WorkspaceId { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglGetWorkspaceOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    public TogglGetWorkspaceOptions(int workspaceId) {
        WorkspaceId = workspaceId;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
        return HttpRequest.Get($"/api/v9/workspaces/{WorkspaceId}");
    }

    #endregion

}
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Tags;

/// <summary>
/// Options describing a request for getting a list of all tags in a Toggl workspace.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/tags#get-tags</cref>
/// </see>
public class TogglGetTagsOptions : TogglTrackHttpRequestOptions {

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
    public TogglGetTagsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    public TogglGetTagsOptions(int workspaceId) {
        WorkspaceId = workspaceId;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Input validation
        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));

        // Initialize a new GET request
        return HttpRequest.Get($"/api/v9/workspaces/{WorkspaceId}/tags");

    }

    #endregion

}
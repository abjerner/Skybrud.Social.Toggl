using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Projects;

/// <summary>
/// Options describing a request for getting a single Toggl project.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceproject</cref>
/// </see>
public class TogglGetProjectOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the parent workspace.
    /// </summary>
    public int WorkspaceId { get; }

    /// <summary>
    /// Gets or sets the ID of the project.
    /// </summary>
    public int ProjectId { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent project.</param>
    /// <param name="projectId">The ID of the project.</param>
    public TogglGetProjectOptions(int workspaceId, int projectId) {
        WorkspaceId = workspaceId;
        ProjectId = projectId;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
        if (ProjectId == 0) throw new PropertyNotSetException(nameof(ProjectId));
        return HttpRequest.Get($"/api/v9/workspaces/{WorkspaceId}/projects/{ProjectId}");
    }

    #endregion

}
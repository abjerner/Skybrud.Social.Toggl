using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;

namespace Skybrud.Social.Toggl.Options.Track.Projects;

/// <summary>
/// Options describing a request for deleting a Toggl project.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/projects#delete-workspaceproject</cref>
/// </see>
public class TogglDeleteProjectOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the parent workspace.
    /// </summary>
    public int WorkspaceId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the project to be deleted.
    /// </summary>
    public int ProjectId { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglDeleteProjectOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/> and <paramref name="projectId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="projectId">The ID of the project to be deleted.</param>
    public TogglDeleteProjectOptions(int workspaceId, int projectId) {
        WorkspaceId = workspaceId;
        ProjectId = projectId;
    }

    /// <summary>
    /// Initializes a new instance from an existing <paramref name="project"/>.
    /// </summary>
    /// <param name="project">The project to be deleted.</param>
    public TogglDeleteProjectOptions(TogglProject project) {
        WorkspaceId = project.WorkspaceId;
        ProjectId = project.Id;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
        if (ProjectId == 0) throw new PropertyNotSetException(nameof(ProjectId));
        return HttpRequest.Delete($"/api/v9/workspaces/{WorkspaceId}/projects/{ProjectId}");
    }

    #endregion

}
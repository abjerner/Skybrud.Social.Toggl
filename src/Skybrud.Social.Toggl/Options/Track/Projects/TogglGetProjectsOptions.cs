using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Projects;

/// <summary>
/// Options describing a request for getting all client in a workspace.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/projects#get-workspaceprojects</cref>
/// </see>
public class TogglGetProjectsOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the workspace.
    /// </summary>
    public int WorkspaceId { get; set; }

    /// <summary>
    /// Gets or sets the active state that the returned projects should match. Default is <see langword="null"/>, meaning both active and inactive projects will be returned.
    /// </summary>
    public bool? Active { get; set; }

    // TODO: Add support for more properties/parameters

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglGetProjectsOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    public TogglGetProjectsOptions(int workspaceId) {
        WorkspaceId = workspaceId;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="active">The active state that the returned projects should match.</param>
    public TogglGetProjectsOptions(int workspaceId, bool? active) {
        WorkspaceId = workspaceId;
        Active = active;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));

        // Initialize the query string
        IHttpQueryString query = new HttpQueryString();
        if (Active is not null) query.Add("active", Active.Value ? "true" : "false");

        // Initialize a new request
        return HttpRequest.Get($"/api/v9/workspaces/{WorkspaceId}/projects", query);

    }

    #endregion

}
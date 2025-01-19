using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;

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
#if NET8_0_OR_GREATER
    public required int WorkspaceId { get; set; }
#else
    public int WorkspaceId { get; set; }
#endif

    /// <summary>
    /// Gets or sets the active state that the returned projects should match. Default is <see langword="null"/>, meaning both active and inactive projects will be returned.
    /// </summary>
    public bool? Active { get; set; }

    /// <summary>
    /// Retrieve projects created/modified/deleted since this timestamp.
    /// </summary>
    public EssentialsTime? Since { get; set; }

    /// <summary>
    /// Gets or sets a list of client IDs the returned project should match.
    /// </summary>
    public List<long> ClientIds { get; set; } = [];

    /// <summary>
    /// Gets or sets a list of group IDs the returned project should match.
    /// </summary>
    public List<long> GroupIds { get; set; } = [];

    /// <summary>
    /// Gets or sets a list of statuses the returned project should match.
    /// </summary>
    public List<string> Statuses { get; set; } = [];

    /// <summary>
    /// Gets or sets a name the returned projects should match.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the page to be returned.
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Gets or sets the number of projects per page, default <c>151</c>. Cannot exceed <c>200</c>.
    /// </summary>
    public int? PerPage { get; set; }

    /// <summary>
    /// Gets or sets the field that the returned projects should be sorted by.
    /// </summary>
    public TogglProjectField? SortField { get; set; }

    /// <summary>
    /// Gets or sets the sort order.
    /// </summary>
    public SortOrder? SortOrder { get; set; }

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
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public TogglGetProjectsOptions(int workspaceId) {
        WorkspaceId = workspaceId;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="active">The active state that the returned projects should match.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
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
        if (Since is not null) query.Add("since", Since.UnixTimeSeconds);
        if (ClientIds is { Count: > 0 }) query.Add("client_ids", ClientIds.Join(","));
        if (GroupIds is { Count: > 0 }) query.Add("group_ids", GroupIds.Join(","));
        if (Statuses is { Count: > 0 }) query.Add("statuses", Statuses.Join(",").ToLowerInvariant());
        if (!string.IsNullOrWhiteSpace(Name)) query.Add("name", Name!);
        if (Page is not null) query.Add("page", Page.Value);
        if (PerPage is not null) query.Add("per_page", PerPage);
        if (SortField is not null) query.Add("sort_field", SortField.ToUnderscore());
        if (SortOrder is not null) query.Add("sort_order", TogglUtils.ToString(SortOrder));

        // Initialize a new request
        return HttpRequest.Get($"/api/v9/workspaces/{WorkspaceId}/projects", query);

    }

    #endregion

}
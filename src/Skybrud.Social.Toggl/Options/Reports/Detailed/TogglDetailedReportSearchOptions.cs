using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Reports.Detailed;

namespace Skybrud.Social.Toggl.Options.Reports.Detailed;

/// <summary>
/// Options describing a request for searching through time entries.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
/// </see>
public class TogglDetailedReportSearchOptions : TogglTrackHttpRequestOptions {

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
    /// Gets or sets the start date to filter by. Should be less than <see cref="EndDate"/>.
    /// </summary>
    public EssentialsDate? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date to filter by. Should be greater than <see cref="StartDate"/>.
    /// </summary>
    public EssentialsDate? EndDate { get; set; }

    /// <summary>
    /// Gets or sets the field to order by.
    /// </summary>
    public TogglDetailedReportTimeEntryField? OrderBy { get; set; }

    /// <summary>
    /// Gets or sets the order direction.
    /// </summary>
    public SortOrder? OrderDirection { get; set; }

    /// <summary>
    /// If <see langword="true"/>, will force the detailed report to return as much information as possible, as it does for the export.
    /// </summary>
    public bool? EnrichResponse { get; set; }

    /// <summary>
    /// Gets or sets the number of items per page, optional, default 50.
    /// </summary>
    public int? PageSize { get; set; }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));

        JObject body = [];
        if (StartDate is not null) body.Add("start_date", StartDate.ToString());
        if (EndDate is not null) body.Add("end_date", EndDate.ToString());

        if (OrderBy is not null) body.Add("order_by", OrderBy.ToUnderscore());
        if (OrderDirection is not null) body.Add("order_dir", OrderDirection.Value == SortOrder.Descending ? "DESC" : "ASC");

        if (EnrichResponse is not null) body.Add("enrich_response", EnrichResponse.Value);
        if (PageSize is not null) body.Add("page_size", PageSize.Value);

        return HttpRequest.Post($"/reports/api/v3/workspace/{WorkspaceId}/search/time_entries", body);

    }

    #endregion

}
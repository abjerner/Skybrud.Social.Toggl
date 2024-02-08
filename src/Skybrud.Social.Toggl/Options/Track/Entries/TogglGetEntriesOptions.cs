using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Entries;

/// <summary>
/// Class describing a request to get time entries for the authenticated user
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/time_entries/index.html#get-timeentries</cref>
/// </see>
public class TogglGetEntriesOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets whether the response should contain data for meta entities.
    /// </summary>
    public bool? Meta { get; set; }

    /// <summary>
    /// Gets or sets the start date.
    /// </summary>
    public EssentialsTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date.
    /// </summary>
    public EssentialsTime? EndDate { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglGetEntriesOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="startDate"/>. and <paramref name="endDate"/>.
    /// </summary>
    public TogglGetEntriesOptions(EssentialsTime? startDate, EssentialsTime? endDate) {
        StartDate = startDate;
        EndDate = endDate;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        HttpQueryString query = new();
        if (Meta is not null) query.Add("meta", Meta.Value ? "true" : "false");
        if (StartDate is not null) query.Add("start_date", StartDate.Iso8601);
        if (EndDate is not null) query.Add("end_date", EndDate.Iso8601);

        return HttpRequest.Get("/api/v9/me/time_entries", query);

    }

    #endregion

}
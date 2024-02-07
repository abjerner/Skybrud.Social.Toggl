using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Options.Track.Entries;
using Skybrud.Social.Toggl.Responses.Track.Entries;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the <strong>Entries</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md</cref>
/// </see>
public class TogglEntriesEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglEntriesRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    internal TogglEntriesEndpoint(TogglHttpService service) {
        Service = service;
        Raw = service.Client.Track.Entries;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Creates a new time entry wqith the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">Theoptions for the request to the Toggl API.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#post-timeentries</cref>
    /// </see>
    public TogglEntryResponse CreateEntry(TogglCreateTimeEntryOptions options) {
        return new TogglEntryResponse(Raw.CreateEntry(options));
    }

    /// <summary>
    /// Get details about the time entry with the specified <paramref name="entryId"/>.
    /// </summary>
    /// <param name="entryId">The ID of the time entry.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public TogglEntryResponse GetEntry(int entryId) {
        return new TogglEntryResponse(Raw.GetEntry(entryId));
    }

    /// <summary>
    /// Gets a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="startDate">Only time entries after this date are returned.</param>
    /// <param name="endDate">Only time entries before this date are returned.</param>
    /// <returns>An instance of <see cref="TogglEntryListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entries-started-in-a-specific-time-range</cref>
    /// </see>
    public TogglEntryListResponse GetEntries(EssentialsTime startDate, EssentialsTime endDate) {
        return new TogglEntryListResponse(Raw.GetEntries(startDate, endDate));
    }

    #endregion

}
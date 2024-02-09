using System.Threading.Tasks;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Options.Track.Entries;
using Skybrud.Social.Toggl.Responses.Track.Entries;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the <strong>Entries</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/time_entries</cref>
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

    #region GetEntries(...)

    /// <summary>
    /// Returns a list of time entries of the authenticated user. Only time entries started during the last 9 days are returned.
    /// </summary>
    /// <returns>An instance of <see cref="TogglEntryListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public TogglEntryListResponse GetEntries() {
        return new TogglEntryListResponse(Raw.GetEntries());
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="startDate">Only time entries after this date are returned.</param>
    /// <param name="endDate">Only time entries before this date are returned.</param>
    /// <returns>An instance of <see cref="TogglEntryListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public TogglEntryListResponse GetEntries(EssentialsTime startDate, EssentialsTime endDate) {
        return new TogglEntryListResponse(Raw.GetEntries(startDate, endDate));
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglEntryListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public TogglEntryListResponse GetEntries(TogglGetEntriesOptions options) {
        return new TogglEntryListResponse(Raw.GetEntries(options));
    }

    #endregion

    #region GetEntriesAsync(...)

    /// <summary>
    /// Returns a list of time entries of the authenticated user. Only time entries started during the last 9 days are returned.
    /// </summary>
    /// <returns>An instance of <see cref="TogglEntryListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public async Task<TogglEntryListResponse> GetEntriesAsync() {
        return new TogglEntryListResponse(await Raw.GetEntriesAsync());
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="startDate">Only time entries after this date are returned.</param>
    /// <param name="endDate">Only time entries before this date are returned.</param>
    /// <returns>An instance of <see cref="TogglEntryListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public async Task<TogglEntryListResponse> GetEntriesAsync(EssentialsTime startDate, EssentialsTime endDate) {
        return new TogglEntryListResponse(await Raw.GetEntriesAsync(startDate, endDate));
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglEntryListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public async Task<TogglEntryListResponse> GetEntriesAsync(TogglGetEntriesOptions options) {
        return new TogglEntryListResponse(await Raw.GetEntriesAsync(options));
    }

    #endregion

    #region CreateEntry(...)

    /// <summary>
    /// Creates a new time entry with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">Theoptions for the request to the Toggl API.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#post-timeentries</cref>
    /// </see>
    public TogglEntryResponse CreateEntry(TogglCreateEntryOptions options) {
        return new TogglEntryResponse(Raw.CreateEntry(options));
    }

    #endregion

    #region CreateEntryAsync(...)

    /// <summary>
    /// Creates a new time entry with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">Theoptions for the request to the Toggl API.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#post-timeentries</cref>
    /// </see>
    public async Task<TogglEntryResponse> CreateEntryAsync(TogglCreateEntryOptions options) {
        return new TogglEntryResponse(await Raw.CreateEntryAsync(options));
    }

    #endregion

    #region GetEntry(...)

    /// <summary>
    /// Get details about the time entry with the specified <paramref name="entryId"/>.
    /// </summary>
    /// <param name="entryId">The ID of the time entry.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public TogglEntryResponse GetEntry(long entryId) {
        return new TogglEntryResponse(Raw.GetEntry(entryId));
    }

    /// <summary>
    /// gets information about the time entry identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public TogglEntryResponse GetEntry(TogglGetEntryOptions options) {
        return new TogglEntryResponse(Raw.GetEntry(options));
    }

    #endregion

    #region GetEntryAsync(...)

    /// <summary>
    /// Get details about the time entry with the specified <paramref name="entryId"/>.
    /// </summary>
    /// <param name="entryId">The ID of the time entry.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public async Task<TogglEntryResponse> GetEntryAsync(long entryId) {
        return new TogglEntryResponse(await Raw.GetEntryAsync(entryId));
    }

    /// <summary>
    /// gets information about the time entry identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="TogglEntryResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public async Task<TogglEntryResponse> GetEntryAsync(TogglGetEntryOptions options) {
        return new TogglEntryResponse(await Raw.GetEntryAsync(options));
    }

    #endregion

    #endregion

}
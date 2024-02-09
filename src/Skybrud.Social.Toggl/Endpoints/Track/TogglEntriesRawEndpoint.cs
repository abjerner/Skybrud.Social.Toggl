using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Track.Entries;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Raw implementation of the <strong>Entries</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/time_entries</cref>
/// </see>
public class TogglEntriesRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the HTTP client.
    /// </summary>
    public TogglHttpClient Client { get; }

    #endregion

    #region Constructors

    internal TogglEntriesRawEndpoint(TogglHttpClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a list of time entries of the authenticated user. Only time entries started during the last 9 days are returned.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public IHttpResponse GetEntries() {
        return GetEntries(new TogglGetEntriesOptions());
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="startDate">Only time entries after this date are returned.</param>
    /// <param name="endDate">Only time entries before this date are returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public IHttpResponse GetEntries(EssentialsTime startDate, EssentialsTime endDate) {
        if (startDate == null) throw new ArgumentNullException(nameof(startDate));
        if (endDate == null) throw new ArgumentNullException(nameof(endDate));
        return GetEntries(new TogglGetEntriesOptions(startDate, endDate));
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public IHttpResponse GetEntries(TogglGetEntriesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user. Only time entries started during the last 9 days are returned.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public async Task<IHttpResponse> GetEntriesAsync() {
        return await GetEntriesAsync(new TogglGetEntriesOptions());
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="startDate">Only time entries after this date are returned.</param>
    /// <param name="endDate">Only time entries before this date are returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public async Task<IHttpResponse> GetEntriesAsync(EssentialsTime startDate, EssentialsTime endDate) {
        if (startDate == null) throw new ArgumentNullException(nameof(startDate));
        if (endDate == null) throw new ArgumentNullException(nameof(endDate));
        return await GetEntriesAsync(new TogglGetEntriesOptions(startDate, endDate));
    }

    /// <summary>
    /// Returns a list of time entries of the authenticated user.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-timeentries</cref>
    /// </see>
    public async Task<IHttpResponse> GetEntriesAsync(TogglGetEntriesOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Creates a new time entry with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">Theoptions for the request to the Toggl API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#post-timeentries</cref>
    /// </see>
    public IHttpResponse CreateEntry(TogglCreateEntryOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Creates a new time entry with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">Theoptions for the request to the Toggl API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#post-timeentries</cref>
    /// </see>
    public async Task<IHttpResponse> CreateEntryAsync(TogglCreateEntryOptions options) {
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Get details about the time entry with the specified <paramref name="entryId"/>.
    /// </summary>
    /// <param name="entryId">The ID of the time entry.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public IHttpResponse GetEntry(long entryId) {
        return GetEntry(new TogglGetEntryOptions(entryId));
    }

    /// <summary>
    /// gets information about the time entry identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public IHttpResponse GetEntry(TogglGetEntryOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Get details about the time entry with the specified <paramref name="entryId"/>.
    /// </summary>
    /// <param name="entryId">The ID of the time entry.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public async Task<IHttpResponse> GetEntryAsync(long entryId) {
        return await GetEntryAsync(new TogglGetEntryOptions(entryId));
    }

    /// <summary>
    /// gets information about the time entry identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options describing the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id</cref>
    /// </see>
    public async Task<IHttpResponse> GetEntryAsync(TogglGetEntryOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}
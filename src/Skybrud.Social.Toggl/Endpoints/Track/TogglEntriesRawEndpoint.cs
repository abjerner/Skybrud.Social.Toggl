﻿using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;
using Skybrud.Social.Toggl.Contants;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Track.Entries;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Raw implementation of the <strong>Entries</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md</cref>
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
        return Client.Get($"https://{TogglConstants.Track.HostName}/api/v9/me/time_entries");
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
        return Client.Get($"https://{TogglConstants.Track.HostName}/api/v9/me/time_entries", new HttpQueryString {
            {"start_date", startDate.ToString(Iso8601Constants.DateTimeSeconds)},
            {"end_date", endDate.ToString(Iso8601Constants.DateTimeSeconds)}
        });
    }

    /// <summary>
    /// Creates a new time entry wqith the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">Theoptions for the request to the Toggl API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/time_entries#post-timeentries</cref>
    /// </see>
    public IHttpResponse CreateEntry(TogglCreateTimeEntryOptions options) {
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
    public IHttpResponse GetEntry(int entryId) {
        return Client.Get($"https://{TogglConstants.Track.HostName}/api/v9/me/time_entries/{entryId}");
    }

    #endregion

}
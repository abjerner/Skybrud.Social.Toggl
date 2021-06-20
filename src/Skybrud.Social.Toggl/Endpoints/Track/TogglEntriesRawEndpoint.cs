using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Track.Entries;

namespace Skybrud.Social.Toggl.Endpoints.Track {

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
        /// Creates a new time entry wqith the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">Theoptions for the request to the Toggl API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#create-a-time-entry</cref>
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
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entry-details</cref>
        /// </see>
        public IHttpResponse GetEntry(int entryId) {
            return Client.Get($"/api/v8/time_entries/{entryId}");
        }

        /// <summary>
        /// Gets a list of time entries of the authenticated user. Only time entries started during the last 9 days are returned.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entries-started-in-a-specific-time-range</cref>
        /// </see>
        public IHttpResponse GetEntries() {
            return Client.Get("/api/v8/time_entries");
        }

        /// <summary>
        /// Gets a list of time entries of the authenticated user.
        /// </summary>
        /// <param name="startDate">Only time entries after this date are returned.</param>
        /// <param name="endDate">Only time entries before this date are returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entries-started-in-a-specific-time-range</cref>
        /// </see>
        public IHttpResponse GetEntries(EssentialsTime startDate, EssentialsTime endDate) {
            if (startDate == null) throw new ArgumentNullException(nameof(startDate));
            if (endDate == null) throw new ArgumentNullException(nameof(endDate));
            return Client.Get("/api/v8/time_entries", new HttpQueryString {
                {"start_date", startDate.ToString(TimeUtils.Iso8601DateFormat)},
                {"end_date", endDate.ToString(TimeUtils.Iso8601DateFormat)}
            });
        }

        #endregion

    }

}
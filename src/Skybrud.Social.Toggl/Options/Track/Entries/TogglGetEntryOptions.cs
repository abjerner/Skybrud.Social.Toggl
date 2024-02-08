using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Entries;

/// <summary>
/// Class describing a request for getting a Track time entry.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/time_entries/index.html#get-get-a-time-entry-by-id</cref>
/// </see>
public class TogglGetEntryOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the entry.
    /// </summary>
    public long EntryId { get; set; }

    /// <summary>
    /// Gets or sets whether the response should contain data for meta entities.
    /// </summary>
    public bool? Meta { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglGetEntryOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="entryId"/>.
    /// </summary>
    public TogglGetEntryOptions(long entryId) {
        EntryId = entryId;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        HttpQueryString query = new();
        if (Meta is not null) query.Add("meta", Meta.Value ? "true" : "false");

        return HttpRequest.Get($"/api/v9/me/time_entries/{EntryId}", query);

    }

    #endregion

}
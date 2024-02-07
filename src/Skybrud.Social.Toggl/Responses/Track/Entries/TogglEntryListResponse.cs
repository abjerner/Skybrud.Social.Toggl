using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Entries;

namespace Skybrud.Social.Toggl.Responses.Track.Entries;

/// <summary>
/// Class representing a response with a list of <see cref="TogglEntry"/>.
/// </summary>
public class TogglEntryListResponse : TogglResponse<IReadOnlyList<TogglEntry>> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglEntryListResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonArray(response.Body, TogglEntry.Parse)!;
    }

}
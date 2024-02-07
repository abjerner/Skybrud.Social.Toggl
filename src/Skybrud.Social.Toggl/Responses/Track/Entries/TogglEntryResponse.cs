using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Entries;

namespace Skybrud.Social.Toggl.Responses.Track.Entries;

/// <summary>
/// Class representing a response with a single <see cref="TogglEntry"/>.
/// </summary>
public class TogglEntryResponse : TogglResponse<TogglEntryResponseBody> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglEntryResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, TogglEntryResponseBody.Parse)!;
    }

}
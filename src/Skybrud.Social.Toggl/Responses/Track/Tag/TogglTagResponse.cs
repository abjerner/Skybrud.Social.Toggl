using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Tags;

namespace Skybrud.Social.Toggl.Responses.Track.Tag;

/// <summary>
/// Class representing a response with information about a tag.
/// </summary>
public class TogglTagResponse : TogglResponse<TogglTag> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglTagResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, TogglTag.Parse)!;
    }

}
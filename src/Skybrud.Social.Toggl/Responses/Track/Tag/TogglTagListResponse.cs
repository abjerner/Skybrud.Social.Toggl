using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Tags;

namespace Skybrud.Social.Toggl.Responses.Track.Tag;

/// <summary>
/// Class representing a response with a list of <see cref="TogglTag"/>.
/// </summary>
public class TogglTagListResponse : TogglResponse<IReadOnlyList<TogglTag>> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglTagListResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonArray(response.Body, TogglTag.Parse)!;
    }

}
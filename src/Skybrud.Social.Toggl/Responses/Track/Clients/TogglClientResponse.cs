using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Responses.Track.Clients;

/// <summary>
/// Class representing a response with a single <see cref="TogglClient"/>.
/// </summary>
public class TogglClientResponse : TogglResponse<TogglClientResult> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglClientResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, TogglClientResult.Parse)!;
    }

}
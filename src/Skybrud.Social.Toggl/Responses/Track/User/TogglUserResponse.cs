using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.User;

namespace Skybrud.Social.Toggl.Responses.Track.User;

/// <summary>
/// Class representing a response with a single <see cref="TogglUser"/>.
/// </summary>
public class TogglUserResponse : TogglResponse<TogglUser> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglUserResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, TogglUser.Parse)!;
    }

}
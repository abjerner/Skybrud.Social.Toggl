using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;

namespace Skybrud.Social.Toggl.Responses.Track.Projects;

/// <summary>
/// Class representing a response with a single <see cref="TogglProject"/>.
/// </summary>
public class TogglProjectResponse : TogglResponse<TogglProject> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglProjectResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, TogglProject.Parse)!;
    }

}
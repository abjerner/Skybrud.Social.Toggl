using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;
using Skybrud.Social.Toggl.Models.Track.Workspaces;

namespace Skybrud.Social.Toggl.Responses.Track.Workspaces;

/// <summary>
/// Class representing a response with a single <see cref="TogglProject"/>.
/// </summary>
public class TogglWorkspaceResponse : TogglResponse<TogglWorkspaceResponseBody> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglWorkspaceResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, TogglWorkspaceResponseBody.Parse)!;
    }

}
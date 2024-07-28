using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Organizations;

namespace Skybrud.Social.Toggl.Responses.Track.Organizations;

/// <summary>
/// Class representing a response with a single <see cref="TogglOrganization"/>.
/// </summary>
public class TogglOrganizationResponse : TogglResponse<TogglOrganization> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglOrganizationResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonObject(response.Body, TogglOrganization.Parse)!;
    }

}
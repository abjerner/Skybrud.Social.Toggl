using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Organizations;

namespace Skybrud.Social.Toggl.Responses.Track.Organizations;

/// <summary>
/// Class representing a response with a list of <see cref="TogglOrganization"/>.
/// </summary>
public class TogglOrganizationListResponse : TogglResponse<IReadOnlyList<TogglOrganization>> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglOrganizationListResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonArray(response.Body, TogglOrganization.Parse)!;
    }

}
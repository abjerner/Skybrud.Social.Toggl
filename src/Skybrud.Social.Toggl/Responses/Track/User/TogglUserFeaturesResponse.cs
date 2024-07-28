using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.User;

namespace Skybrud.Social.Toggl.Responses.Track.User;

/// <summary>
/// Class representing a response with a list of <see cref="TogglUserFeatureList"/>.
/// </summary>
public class TogglUserFeaturesResponse : TogglResponse<IReadOnlyList<TogglUserFeatureList>> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglUserFeaturesResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonArray(response.Body, TogglUserFeatureList.Parse)!;
    }

}
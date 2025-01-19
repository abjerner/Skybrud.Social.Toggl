using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Reports.Detailed;

namespace Skybrud.Social.Toggl.Responses.Reports.Detailed;

/// <summary>
/// Class representing a response where the body is a list of <see cref="TogglDetailedReportTimeEntryGroup"/>.
/// </summary>
public class TogglDetailedReportSearchResponse : TogglResponse<IReadOnlyList<TogglDetailedReportTimeEntryGroup>> {

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The raw response received from the Toggl API.</param>
    public TogglDetailedReportSearchResponse(IHttpResponse response) : base(response) {
        Body = ParseJsonArray(response.Body, TogglDetailedReportTimeEntryGroup.Parse);
    }

}
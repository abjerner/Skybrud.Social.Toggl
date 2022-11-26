using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;

namespace Skybrud.Social.Toggl.Responses.Track.Projects {

    /// <summary>
    /// Class representing a response with a list of <see cref="TogglProject"/>.
    /// </summary>
    public class TogglProjectListResponse : TogglResponse<IReadOnlyList<TogglProject>> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglProjectListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglProject.Parse)!;
        }

    }

}
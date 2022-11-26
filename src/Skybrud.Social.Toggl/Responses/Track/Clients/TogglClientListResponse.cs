using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Responses.Track.Clients {

    /// <summary>
    /// Class representing a response with a list of <see cref="TogglClient"/>.
    /// </summary>
    public class TogglClientListResponse : TogglResponse<IReadOnlyList<TogglClient>> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglClientListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglClient.Parse)!;
        }

    }

}
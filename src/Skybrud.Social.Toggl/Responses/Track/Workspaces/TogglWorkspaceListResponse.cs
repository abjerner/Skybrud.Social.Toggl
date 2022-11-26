using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Workspaces;

namespace Skybrud.Social.Toggl.Responses.Track.Workspaces {

    /// <summary>
    /// Class representing a response with a list of <see cref="TogglWorkspace"/>.
    /// </summary>
    public class TogglWorkspaceListResponse : TogglResponse<IReadOnlyList<TogglWorkspace>> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglWorkspaceListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglWorkspace.Parse)!;
        }

    }

}
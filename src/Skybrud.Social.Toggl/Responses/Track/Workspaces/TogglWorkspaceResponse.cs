using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;
using Skybrud.Social.Toggl.Models.Track.Workspaces;

namespace Skybrud.Social.Toggl.Responses.Track.Workspaces {

    /// <summary>
    /// Class representing a response with a single <see cref="TogglProject"/>.
    /// </summary>
    public class TogglWorkspaceResponse : TogglResponse<TogglWorkspaceResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglWorkspaceResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglWorkspaceResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        /// <returns>An instance of <see cref="TogglWorkspaceResponse"/> representing the response.</returns>
        public static TogglWorkspaceResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglWorkspaceResponse(response);
        }

        #endregion

    }

}
using System;
using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Workspaces;

namespace Skybrud.Social.Toggl.Responses.Track.Workspaces {

    /// <summary>
    /// Class representing a response with a list of <see cref="TogglWorkspace"/>.
    /// </summary>
    public class TogglWorkspaceListResponse : TogglResponse<IReadOnlyList<TogglWorkspace>> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglWorkspaceListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglWorkspace.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        /// <returns>An instance of <see cref="TogglWorkspaceListResponse"/> representing the response.</returns>
        public static TogglWorkspaceListResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglWorkspaceListResponse(response);
        }

        #endregion

    }

}
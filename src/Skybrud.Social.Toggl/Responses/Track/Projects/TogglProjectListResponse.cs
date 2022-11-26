using System;
using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;

namespace Skybrud.Social.Toggl.Responses.Track.Projects {

    /// <summary>
    /// Class representing a response with a list of <see cref="TogglProject"/>.
    /// </summary>
    public class TogglProjectListResponse : TogglResponse<IReadOnlyList<TogglProject>> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglProjectListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglProject.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        /// <returns>An instance of <see cref="TogglProjectListResponse"/> representing the response.</returns>
        public static TogglProjectListResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglProjectListResponse(response);
        }

        #endregion

    }

}
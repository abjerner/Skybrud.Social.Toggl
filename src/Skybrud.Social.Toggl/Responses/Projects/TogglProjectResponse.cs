using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Projects;

namespace Skybrud.Social.Toggl.Responses.Projects {

    /// <summary>
    /// Class representing a response with a single <see cref="TogglProject"/>.
    /// </summary>
    public class TogglProjectResponse : TogglResponse<TogglProjectResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglProjectResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglProjectResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        /// <returns>An instance of <see cref="TogglProjectResponse"/> representing the response.</returns>
        public static TogglProjectResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglProjectResponse(response);
        }

        #endregion

    }

}
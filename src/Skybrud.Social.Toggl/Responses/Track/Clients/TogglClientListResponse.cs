using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Responses.Track.Clients {

    /// <summary>
    /// Class representing a response with a list of <see cref="TogglClient"/>.
    /// </summary>
    public class TogglClientListResponse : TogglResponse<TogglClient[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglClientListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglClient.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response.</returns>
        public static TogglClientListResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglClientListResponse(response);
        }

        #endregion

    }

}
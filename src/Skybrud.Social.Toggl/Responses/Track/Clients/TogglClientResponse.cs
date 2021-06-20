using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Responses.Track.Clients {

    /// <summary>
    /// Class representing a response with a single <see cref="TogglClient"/>.
    /// </summary>
    public class TogglClientResponse : TogglResponse<TogglClientResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglClientResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglClientResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response.</returns>
        public static TogglClientResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglClientResponse(response);
        }

        #endregion

    }

}
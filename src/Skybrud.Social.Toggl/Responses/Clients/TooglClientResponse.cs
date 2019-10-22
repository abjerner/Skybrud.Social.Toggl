using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Clients;

namespace Skybrud.Social.Toggl.Responses.Clients {

    /// <summary>
    /// Class representing a response with a single <see cref="TogglClient"/>.
    /// </summary>
    public class TooglClientResponse : TogglResponse<TogglClientResponseBody> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TooglClientResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglClientResponseBody.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        /// <returns>An instance of <see cref="TooglClientResponse"/> representing the response.</returns>
        public static TooglClientResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TooglClientResponse(response);
        }

        #endregion

    }

}
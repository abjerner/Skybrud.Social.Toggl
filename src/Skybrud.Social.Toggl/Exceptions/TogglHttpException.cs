using System;
using System.Net;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Toggl.Exceptions {

    public class TogglHttpException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the Toggl API.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        #endregion

        #region Constructors

        public TogglHttpException(IHttpResponse responses) : base("Invalid response received from the Toggl API (Status: " + (int) responses.StatusCode + ")") {
            Response = responses;
        }

        #endregion

    }

}
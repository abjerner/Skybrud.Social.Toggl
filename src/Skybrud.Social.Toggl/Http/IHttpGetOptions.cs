using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Social.Toggl.Http {

    /// <summary>
    /// Interface representing the options for making a <strong>GET</strong> request to the Toggl API.
    /// </summary>
    public interface IHttpGetOptions {

        /// <summary>
        /// Returns the URL of the endpoint to be requested.
        /// </summary>
        /// <returns>The endpoint URL.</returns>
        string GetUrl();

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters of the request.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        IHttpQueryString GetQueryString();

    }

}
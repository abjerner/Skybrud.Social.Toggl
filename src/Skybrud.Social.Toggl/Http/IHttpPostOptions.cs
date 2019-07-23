using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http.Collections;

namespace Skybrud.Social.Toggl.Http {

    /// <summary>
    /// Interface representing the options for making a <strong>POST</strong> request to the Toggl API with an instance of <typeparamref name="T"/> as the request body.
    /// </summary>
    public interface IHttpPostOptions<out T> where T : JToken {

        #region Methods

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

        /// <summary>
        /// Gets the <see cref="JToken"/> that represents the POST body of the request.
        /// </summary>
        /// <returns>An instance of <typeparamref name="T"/>.</returns>
        T GetBody();

        #endregion

    }

}
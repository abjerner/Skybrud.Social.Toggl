using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Security;
using Skybrud.Social.Toggl.Apis;

namespace Skybrud.Social.Toggl.Http {

    /// <summary>
    /// Class for handling the HTTP communication with the Toggl API.
    /// </summary>
    public class TogglHttpClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the API token.
        /// </summary>
        public string ApiToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Track</strong> API.
        /// </summary>
        public TogglTrackRawApi Track { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TogglHttpClient() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="apiToken"/>.
        /// </summary>
        /// <param name="apiToken">The access token to be used.</param>
        public TogglHttpClient(string apiToken) {
            ApiToken = apiToken;
            Track = new TogglTrackRawApi(this);
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {
            if (string.IsNullOrWhiteSpace(ApiToken) == false) request.Authorization = "Basic " + SecurityUtils.Base64Encode(ApiToken + ":api_token");
        }

        #endregion

    }

}
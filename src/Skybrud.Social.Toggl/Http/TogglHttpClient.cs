using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Security;
using Skybrud.Social.Toggl.Endpoints.Raw;

namespace Skybrud.Social.Toggl.Http {

    /// <summary>
    /// Class for handling the HTTP communication with the Toggl API.
    /// </summary>
    public class TogglHttpClient : HttpClient {

        #region Properties

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Clients</strong> endpoint.
        /// </summary>
        public TogglClientsRawEndpoint Clients { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Entries</strong> endpoint.
        /// </summary>
        public TogglEntriesRawEndpoint Entries { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Projects</strong> endpoint.
        /// </summary>
        public TogglProjectsRawEndpoint Projects { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Workspaces</strong> endpoint.
        /// </summary>
        public TogglWorkspacesRawEndpoint Workspaces { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TogglHttpClient() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token to be used.</param>
        public TogglHttpClient(string accessToken) {
            AccessToken = accessToken;
            Clients = new TogglClientsRawEndpoint(this);
            Entries = new TogglEntriesRawEndpoint(this);
            Projects = new TogglProjectsRawEndpoint(this);
            Workspaces = new TogglWorkspacesRawEndpoint(this);
        }

        #endregion

        #region Member methods
        

        /// <summary>
        /// Makes a HTTP <strong>GET</strong> request to the Azure REST API with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Get(IHttpGetOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Get(options.GetUrl(), options.GetQueryString());
        }

        /// <summary>
        /// Makes a HTTP <strong>POST</strong> request to the Azure REST API with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Post<T>(IHttpPostOptions<T> options) where T : JToken {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Post(options.GetUrl(), options.GetQueryString(), options.GetBody());
        }

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {
            if (string.IsNullOrWhiteSpace(AccessToken) == false) request.Authorization = "Basic " + SecurityUtils.Base64Encode(AccessToken + ":api_token");
            if (request.Url.StartsWith("/api/")) request.Url = "https://www.toggl.com" + request.Url;
        }

        #endregion

    }

}

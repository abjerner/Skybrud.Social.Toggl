using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Security;
using Skybrud.Social.Toggl.Endpoints.Raw;

namespace Skybrud.Social.Toggl.Http {

    public class TogglHttpClient : HttpClient {

        #region Properties

        public string AccessToken { get; set; }

        public TogglClientsRawEndpoint Clients { get; }

        public TogglEntriesRawEndpoint Entries { get; }

        public TogglProjectsRawEndpoint Projects { get; }

        #endregion

        #region Constructors

        public TogglHttpClient() { }

        public TogglHttpClient(string accessToken) {
            AccessToken = accessToken;
            Clients = new TogglClientsRawEndpoint(this);
            Entries = new TogglEntriesRawEndpoint(this);
            Projects = new TogglProjectsRawEndpoint(this);
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
            return DoHttpGetRequest(options.GetUrl(), options.GetQueryString());
        }

        /// <summary>
        /// Makes a HTTP <strong>POST</strong> request to the Azure REST API with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public virtual IHttpResponse Post<T>(IHttpPostOptions<T> options) where T : JToken {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return DoHttpPutRequest(options.GetUrl(), options.GetQueryString(), options.GetBody());
        }

        protected override void PrepareHttpRequest(IHttpRequest request) {
            if (!string.IsNullOrWhiteSpace(AccessToken)) request.Authorization = "Basic " + SecurityUtils.Base64Encode(AccessToken + ":api_token");
            if (request.Url.StartsWith("/api/")) request.Url = "https://www.toggl.com" + request.Url;
        }

        #endregion

    }

}

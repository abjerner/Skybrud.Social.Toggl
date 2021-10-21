using System;
using Skybrud.Social.Toggl.Apis;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl {

    /// <summary>
    /// Class working as an entry point to making requests to the various endpoints of the Toggl API.
    /// </summary>
    public class TogglHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying HTTP client.
        /// </summary>
        public TogglHttpClient Client { get; set; }

        /// <summary>
        /// Gets a reference to the <strong>Track</strong> API.
        /// </summary>
        public TogglTrackApi Track { get; }

        #endregion

        #region Constructors

        private TogglHttpService(TogglHttpClient client) {
            Client = client;
            Track = new TogglTrackApi(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new instance of <see cref="TogglHttpService"/> based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The HTTP/OAuth client that should be used internally.</param>
        /// <returns>A new instance of <see cref="TogglHttpService"/>.</returns>
        public static TogglHttpService CreateFromClient(TogglHttpClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new TogglHttpService(client);
        }

        /// <summary>
        /// Returns a new instance of <see cref="TogglHttpService"/> based on the specified <paramref name="apiToken"/>.
        /// </summary>
        /// <param name="apiToken">The API token to be used.</param>
        /// <returns>A new instance of <see cref="TogglHttpService"/>.</returns>
        public static TogglHttpService CreateFromApiToken(string apiToken) {
            if (string.IsNullOrWhiteSpace(apiToken)) throw new ArgumentNullException(nameof(apiToken));
            return new TogglHttpService(new TogglHttpClient(apiToken));
        }

        #endregion

    }

}
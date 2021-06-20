using System;
using Skybrud.Social.Toggl.Endpoints.Track;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl {

    /// <summary>
    /// Class working as an entry point to making requests to the various endpoints of the Toggl API.
    /// </summary>
    public class TogglService {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying HTTP client.
        /// </summary>
        public TogglHttpClient Client { get; set; }

        /// <summary>
        /// Gets a reference to the <strong>Clients</strong> endpoint.
        /// </summary>
        public TogglClientsEndpoint Clients { get; }

        /// <summary>
        /// Gets a reference to the <strong>Entries</strong> endpoint.
        /// </summary>
        public TogglEntriesEndpoint Entries { get; }

        /// <summary>
        /// Gets a reference to the <strong>Projects</strong> endpoint.
        /// </summary>
        public TogglProjectsEndpoint Projects { get; }

        /// <summary>
        /// Gets a reference to the <strong>Workspaces</strong> endpoint.
        /// </summary>
        public TogglWorkspacesEndpoint Workspaces { get; }

        #endregion

        #region Constructors

        private TogglService(TogglHttpClient client) {
            Client = client;
            Clients = new TogglClientsEndpoint(this);
            Entries = new TogglEntriesEndpoint(this);
            Projects = new TogglProjectsEndpoint(this);
            Workspaces = new TogglWorkspacesEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Returns a new instance of <see cref="TogglService"/> based on the specified <paramref name="client"/>.
        /// </summary>
        /// <param name="client">The HTTP/OAuth client that should be used internally.</param>
        /// <returns>A new instance of <see cref="TogglService"/>.</returns>
        public static TogglService CreateFromClient(TogglHttpClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new TogglService(client);
        }

        /// <summary>
        /// Returns a new instance of <see cref="TogglService"/> based on the specified <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">The access token to be used.</param>
        /// <returns>A new instance of <see cref="TogglService"/>.</returns>
        public static TogglService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new TogglService(new TogglHttpClient(accessToken));
        }

        #endregion

    }

}
﻿using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Clients;

namespace Skybrud.Social.Toggl.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the <strong>Clients</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md</cref>
    /// </see>
    public class TogglClientsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the HTTP client.
        /// </summary>
        public TogglHttpClient Client { get; }

        #endregion

        #region Constructors

        internal TogglClientsRawEndpoint(TogglHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Creates a new client with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client</cref>
        /// </see>
        public IHttpResponse CreateClient(string name, int workspaceId) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return Client.Post(new TogglCreateClientOptions(name, workspaceId));
        }

        /// <summary>
        /// Creates a new client with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <param name="notes">Notes for the client.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client</cref>
        /// </see>
        public IHttpResponse CreateClient(string name, int workspaceId, string notes) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return Client.Post(new TogglCreateClientOptions(name, workspaceId, notes));
        }

        /// <summary>
        /// Creates a new client based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client</cref>
        /// </see>
        public IHttpResponse CreateClient(TogglCreateClientOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.Post(options);
        }

        /// <summary>
        /// Gets a list of all clients visible to the user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
        /// <see>
        ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user</cref>
        /// </see>
        public IHttpResponse GetClients() {
            return Client.DoHttpGetRequest("/api/v8/clients");
        }

        #endregion

    }

}
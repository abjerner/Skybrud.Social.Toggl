using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Endpoints.Raw;
using Skybrud.Social.Toggl.Options;
using Skybrud.Social.Toggl.Options.Clients;
using Skybrud.Social.Toggl.Responses;
using Skybrud.Social.Toggl.Responses.Clients;

namespace Skybrud.Social.Toggl.Endpoints {

    public class TogglClientsEndpoint {

        #region Properties

        public TogglService Service { get; }

        public TogglClientsRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        public TogglClientsEndpoint(TogglService service) {
            Service = service;
            Raw = service.Client.Clients;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of all clients visible to the user.
        /// </summary>
        /// <returns>An instance of <see cref="TogglClientsResponse"/> representing the response from the Toggl API.</returns>
        public TogglClientsResponse GetClients() {
            return TogglClientsResponse.Parse(Raw.GetClients());
        }

        /// <summary>
        /// Creates a new client with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <returns>An instance of <see cref="TooglCreateClientResponse"/> representing the response from the Toggl API.</returns>
        public TooglCreateClientResponse CreateClient(string name, int workspaceId) {
            return TooglCreateClientResponse.Parse(Raw.CreateClient(name, workspaceId));
        }

        /// <summary>
        /// Creates a new client with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <param name="notes">Notes for the client.</param>
        /// <returns>An instance of <see cref="TooglCreateClientResponse"/> representing the response from the Toggl API.</returns>
        public TooglCreateClientResponse CreateClient(string name, int workspaceId, string notes) {
            return TooglCreateClientResponse.Parse(Raw.CreateClient(name, workspaceId, notes));
        }

        /// <summary>
        /// Creates a new client based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TooglCreateClientResponse"/> representing the response from the Toggl API.</returns>
        public TooglCreateClientResponse CreateClient(TogglCreateClientOptions options) {
            return TooglCreateClientResponse.Parse(Raw.CreateClient(options));
        }

        #endregion

    }

}
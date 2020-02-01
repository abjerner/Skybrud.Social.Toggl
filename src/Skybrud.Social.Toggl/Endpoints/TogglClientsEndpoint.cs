using Skybrud.Social.Toggl.Endpoints.Raw;
using Skybrud.Social.Toggl.Options.Clients;
using Skybrud.Social.Toggl.Responses.Clients;

namespace Skybrud.Social.Toggl.Endpoints {

    /// <summary>
    /// Implementation of the <strong>Clients</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md</cref>
    /// </see>
    public class TogglClientsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public TogglService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TogglClientsRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        internal TogglClientsEndpoint(TogglService service) {
            Service = service;
            Raw = service.Client.Clients;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of all clients visible to the user.
        /// </summary>
        /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response from the Toggl API.</returns>
        public TogglClientListResponse GetClients() {
            return TogglClientListResponse.Parse(Raw.GetClients());
        }

        /// <summary>
        /// Creates a new client with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response from the Toggl API.</returns>
        public TogglClientResponse CreateClient(string name, int workspaceId) {
            return TogglClientResponse.Parse(Raw.CreateClient(name, workspaceId));
        }

        /// <summary>
        /// Creates a new client with the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <param name="notes">Notes for the client.</param>
        /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response from the Toggl API.</returns>
        public TogglClientResponse CreateClient(string name, int workspaceId, string notes) {
            return TogglClientResponse.Parse(Raw.CreateClient(name, workspaceId, notes));
        }

        /// <summary>
        /// Creates a new client based on the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response from the Toggl API.</returns>
        public TogglClientResponse CreateClient(TogglCreateClientOptions options) {
            return TogglClientResponse.Parse(Raw.CreateClient(options));
        }

        #endregion

    }

}
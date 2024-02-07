using Skybrud.Social.Toggl.Models.Track.Clients;
using Skybrud.Social.Toggl.Options.Track.Clients;
using Skybrud.Social.Toggl.Responses;
using Skybrud.Social.Toggl.Responses.Track.Clients;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the <strong>Clients</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients</cref>
/// </see>
public class TogglClientsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglClientsRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    internal TogglClientsEndpoint(TogglHttpService service) {
        Service = service;
        Raw = service.Client.Track.Clients;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Creates a new client with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="name">The name of the client.</param>
    /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-create-client</cref>
    /// </see>
    public TogglClientResponse CreateClient(int workspaceId, string name) {
        return new TogglClientResponse(Raw.CreateClient(workspaceId, name));
    }

    /// <summary>
    /// Creates a new client based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-create-client</cref>
    /// </see>
    public TogglClientResponse CreateClient(TogglCreateClientOptions options) {
        return new TogglClientResponse(Raw.CreateClient(options));
    }

    /// <summary>
    /// Gets information about the client with the specified <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
    /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-load-client-from-id</cref>
    /// </see>
    public TogglClientResponse GetClient(int workspaceId, int clientId) {
        return new TogglClientResponse(Raw.GetClient(workspaceId, clientId));
    }

    /// <summary>
    /// Gets information about the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="TogglClientResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-load-client-from-id</cref>
    /// </see>
    public TogglClientResponse GetClient(TogglGetClientOptions options) {
        return new TogglClientResponse(Raw.GetClient(options));
    }

    /// <summary>
    /// Deletes the client with the specified <paramref name="clientId"/>.
    /// </summary>
    /// <param name="clientId">The ID of the client.</param>
    /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client</cref>
    /// </see>
    public TogglResponse DeleteClient(int clientId) {
        return new TogglResponse(Raw.DeleteClient(clientId));
    }

    /// <summary>
    /// Deletes the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be deleted.</param>
    /// <returns>An instance of <see cref="TogglResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client</cref>
    /// </see>
    public TogglResponse DeleteClient(TogglClient client) {
        return new TogglResponse(Raw.DeleteClient(client));
    }

    /// <summary>
    /// Gets a list of all clients visible to the user.
    /// </summary>
    /// <returns>An instance of <see cref="TogglClientListResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user</cref>
    /// </see>
    public TogglClientListResponse GetClients() {
        return new TogglClientListResponse(Raw.GetClients());
    }

    #endregion

}
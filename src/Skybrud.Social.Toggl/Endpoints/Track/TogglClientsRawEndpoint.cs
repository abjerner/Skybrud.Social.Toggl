using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;
using Skybrud.Social.Toggl.Options.Track.Clients;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Raw implementation of the <strong>Clients</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients</cref>
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

    #region GetClients(...)

    /// <summary>
    /// Returns a list of all clients of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-list-clients</cref>
    /// </see>
    public IHttpResponse GetClients(int workspaceId) {
        return GetClients(new TogglGetClientsOptions(workspaceId));
    }

    /// <summary>
    /// Returns a list of clients identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-list-clients</cref>
    /// </see>
    public IHttpResponse GetClients(TogglGetClientsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region GetClientsAsync(...)

    /// <summary>
    /// Returns a list of all clients of the workspace with the specified <paramref name="workspaceId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-list-clients</cref>
    /// </see>
    public async Task<IHttpResponse> GetClientsAsync(int workspaceId) {
        return await GetClientsAsync(new TogglGetClientsOptions(workspaceId));
    }

    /// <summary>
    /// Returns a list of clients identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-list-clients</cref>
    /// </see>
    public async Task<IHttpResponse> GetClientsAsync(TogglGetClientsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region CreateClient(...)

    /// <summary>
    /// Creates a new client with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="name">The name of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-create-client</cref>
    /// </see>
    public IHttpResponse CreateClient(int workspaceId, string name) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return Client.GetResponse(new TogglCreateClientOptions(workspaceId, name));
    }

    /// <summary>
    /// Creates a new client based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-create-client</cref>
    /// </see>
    public IHttpResponse CreateClient(TogglCreateClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region CreateClientAsync(...)

    /// <summary>
    /// Creates a new client with the specified <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="name">The name of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-create-client</cref>
    /// </see>
    public async Task<IHttpResponse> CreateClientAsync(int workspaceId, string name) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await Client.GetResponseAsync(new TogglCreateClientOptions(workspaceId, name));
    }

    /// <summary>
    /// Creates a new client based on the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-create-client</cref>
    /// </see>
    public async Task<IHttpResponse> CreateClientAsync(TogglCreateClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region GetClient(...)

    /// <summary>
    /// Gets information about the client with the specified <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-load-client-from-id</cref>
    /// </see>
    public IHttpResponse GetClient(int workspaceId, int clientId) {
        return GetClient(new TogglGetClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Gets information about the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-load-client-from-id</cref>
    /// </see>
    public IHttpResponse GetClient(TogglGetClientOptions options) {
        return Client.GetResponse(options);
    }

    #endregion

    #region GetClientAsync(...)

    /// <summary>
    /// Gets information about the client with the specified <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-load-client-from-id</cref>
    /// </see>
    public async Task<IHttpResponse> GetClientAsync(int workspaceId, int clientId) {
        return await GetClientAsync(new TogglGetClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Gets information about the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#get-load-client-from-id</cref>
    /// </see>
    public async Task<IHttpResponse> GetClientAsync(TogglGetClientOptions options) {
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region UpdateClient(...)

    /// <summary>
    /// Updates the client matching the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client to be updated.</param>
    /// <param name="name">The new name of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#put-change-client</cref>
    /// </see>
    public IHttpResponse UpdateClient(int workspaceId, int clientId, string name) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return UpdateClient(new TogglUpdateClientOptions(workspaceId, clientId, name));
    }

    /// <summary>
    /// Updates the name of the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be updated.</param>
    /// <param name="name">The new name of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#put-change-client</cref>
    /// </see>
    public IHttpResponse UpdateClient(TogglClient client, string name) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return UpdateClient(new TogglUpdateClientOptions(client.WorkspaceId, client.Id, name));
    }

    /// <summary>
    /// Updates the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#put-change-client</cref>
    /// </see>
    public IHttpResponse UpdateClient(TogglUpdateClientOptions options) {
        return Client.GetResponse(options);
    }

    #endregion

    #region UpdateClientAsync(...)

    /// <summary>
    /// Updates the client matching the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client to be updated.</param>
    /// <param name="name">The new name of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#put-change-client</cref>
    /// </see>
    public async Task<IHttpResponse> UpdateClientAsync(int workspaceId, int clientId, string name) {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await UpdateClientAsync(new TogglUpdateClientOptions(workspaceId, clientId, name));
    }

    /// <summary>
    /// Updates the name of the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be updated.</param>
    /// <param name="name">The new name of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#put-change-client</cref>
    /// </see>
    public async Task<IHttpResponse> UpdateClientAsync(TogglClient client, string name) {
        if (client is null) throw new ArgumentNullException(nameof(client));
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        return await UpdateClientAsync(new TogglUpdateClientOptions(client.WorkspaceId, client.Id, name));
    }

    /// <summary>
    /// Updates the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#put-change-client</cref>
    /// </see>
    public async Task<IHttpResponse> UpdateClientAsync(TogglUpdateClientOptions options) {
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region ArchiveClient(...)

    /// <summary>
    /// Archives the client matching the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client to be archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-archives-client</cref>
    /// </see>
    public IHttpResponse ArchiveClient(int workspaceId, int clientId) {
        return ArchiveClient(new TogglArchiveClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Archives the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-archives-client</cref>
    /// </see>
    public IHttpResponse ArchiveClient(TogglClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return ArchiveClient(new TogglArchiveClientOptions(client));
    }

    /// <summary>
    /// Archives the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-archives-client</cref>
    /// </see>
    public IHttpResponse ArchiveClient(TogglArchiveClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region ArchiveClientAsync(...)

    /// <summary>
    /// Archives the client matching the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client to be archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-archives-client</cref>
    /// </see>
    public async Task<IHttpResponse> ArchiveClientAsync(int workspaceId, int clientId) {
        return await ArchiveClientAsync(new TogglArchiveClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Archives the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be archived.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-archives-client</cref>
    /// </see>
    public async Task<IHttpResponse> ArchiveClientAsync(TogglClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return await ArchiveClientAsync(new TogglArchiveClientOptions(client));
    }

    /// <summary>
    /// Archives the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-archives-client</cref>
    /// </see>
    public async Task<IHttpResponse> ArchiveClientAsync(TogglArchiveClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region RestoreClient(...)

    /// <summary>
    /// Restores the client matching the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client to be restored.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-restores-client-and-related-projects</cref>
    /// </see>
    public IHttpResponse RestoreClient(int workspaceId, int clientId) {
        return RestoreClient(new TogglRestoreClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Restores the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be restored.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-restores-client-and-related-projects</cref>
    /// </see>
    public IHttpResponse RestoreClient(TogglClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return RestoreClient(new TogglRestoreClientOptions(client));
    }

    /// <summary>
    /// Restores the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-restores-client-and-related-projects</cref>
    /// </see>
    public IHttpResponse RestoreClient(TogglRestoreClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region RestoreClientAsync(...)

    /// <summary>
    /// Restores the client matching the specified <paramref name="workspaceId"/> and <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client to be restored.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-restores-client-and-related-projects</cref>
    /// </see>
    public async Task<IHttpResponse> RestoreClientAsync(int workspaceId, int clientId) {
        return await RestoreClientAsync(new TogglRestoreClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Restores the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be restored.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-restores-client-and-related-projects</cref>
    /// </see>
    public async Task<IHttpResponse> RestoreClientAsync(TogglClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return await RestoreClientAsync(new TogglRestoreClientOptions(client));
    }

    /// <summary>
    /// Restores the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#post-restores-client-and-related-projects</cref>
    /// </see>
    public async Task<IHttpResponse> RestoreClientAsync(TogglRestoreClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #region DeleteClient(...)

    /// <summary>
    /// Deletes the client with the specified <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client</cref>
    /// </see>
    public IHttpResponse DeleteClient(int workspaceId, int clientId) {
        return DeleteClient(new TogglDeleteClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Deletes the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be deleted.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#delete-delete-client</cref>
    /// </see>
    public IHttpResponse DeleteClient(TogglClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return DeleteClient(new TogglDeleteClientOptions(client));
    }

    /// <summary>
    /// Deletes the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#delete-delete-client</cref>
    /// </see>
    public IHttpResponse DeleteClient(TogglDeleteClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

    #region DeleteClientAsync(...)

    /// <summary>
    /// Deletes the client with the specified <paramref name="clientId"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client</cref>
    /// </see>
    public async Task<IHttpResponse> DeleteClientAsync(int workspaceId, int clientId) {
        return await DeleteClientAsync(new TogglDeleteClientOptions(workspaceId, clientId));
    }

    /// <summary>
    /// Deletes the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be deleted.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#delete-delete-client</cref>
    /// </see>
    public async Task<IHttpResponse> DeleteClientAsync(TogglClient client) {
        if (client == null) throw new ArgumentNullException(nameof(client));
        return await DeleteClientAsync(new TogglDeleteClientOptions(client));
    }

    /// <summary>
    /// Deletes the client identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/clients#delete-delete-client</cref>
    /// </see>
    public async Task<IHttpResponse> DeleteClientAsync(TogglDeleteClientOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #endregion

}
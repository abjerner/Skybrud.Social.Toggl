using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Track.User;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Raw implementation of the <strong>User</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/me</cref>
/// </see>
public class TogglUserRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the HTTP client.
    /// </summary>
    public TogglHttpClient Client { get; }

    #endregion

    #region Constructors

    internal TogglUserRawEndpoint(TogglHttpClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/me#get-me</cref>
    /// </see>
    public IHttpResponse GetUser() {
        return Client.Get("https://api.track.toggl.com/api/v9/me");
    }

    /// <summary>
    /// Returns information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/me#get-me</cref>
    /// </see>
    public async Task<IHttpResponse> GetUserAsync() {
        return await Client.GetAsync("https://api.track.toggl.com/api/v9/me");
    }

    /// <summary>
    /// Returns the preferences of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/preferences#get-preferences-for-the-current-user</cref>
    /// </see>
    public IHttpResponse GetUserPreferences() {
        return Client.Get("https://api.track.toggl.com/api/v9/me/preferences");
    }

    /// <summary>
    /// Returns the preferences of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/preferences#get-preferences-for-the-current-user</cref>
    /// </see>
    public async Task<IHttpResponse> GetUserPreferencesAsync() {
        return await Client.GetAsync("https://api.track.toggl.com/api/v9/me/preferences");
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public IHttpResponse GetClients() {
        return GetClients(new TogglGetClientsOptions());
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user created, modified or deleted since the specified timestamp.
    /// </summary>
    /// <param name="since">Only clients created, modified or deleted since this timestamp will be returned</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public IHttpResponse GetClients(EssentialsTime since) {
        return GetClients(new TogglGetClientsOptions { Since = since });
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public IHttpResponse GetClients(TogglGetClientsOptions options) {
        return Client.GetResponse(options);
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public async Task<IHttpResponse> GetClientsAsync() {
        return await GetClientsAsync(new TogglGetClientsOptions());
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user created, modified or deleted since the specified timestamp.
    /// </summary>
    /// <param name="since">Only clients created, modified or deleted since this timestamp will be returned</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public async Task<IHttpResponse> GetClientsAsync(EssentialsTime since) {
        return await GetClientsAsync(new TogglGetClientsOptions { Since = since });
    }

    /// <summary>
    /// Returns a list of all clients of the authenticated user.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
    /// </see>
    public async Task<IHttpResponse> GetClientsAsync(TogglGetClientsOptions options) {
        return await Client.GetResponseAsync(options);
    }

    #endregion

}
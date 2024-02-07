using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Social.Toggl.Http;

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

    #endregion

}
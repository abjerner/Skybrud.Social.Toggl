using Skybrud.Essentials.Http;
using System.Threading.Tasks;
using Skybrud.Social.Toggl.Responses.Track.User;

namespace Skybrud.Social.Toggl.Endpoints.Track;

/// <summary>
/// Implementation of the <strong>User</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/me</cref>
/// </see>
public class TogglUserEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglUserRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    internal TogglUserEndpoint(TogglHttpService service) {
        Service = service;
        Raw = service.Client.Track.User;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/me#get-me</cref>
    /// </see>
    public TogglUserResponse GetUser() {
        return new TogglUserResponse(Raw.GetUser());
    }

    /// <summary>
    /// Returns information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/me#get-me</cref>
    /// </see>
    public async Task<TogglUserResponse> GetUserAsync() {
        return new TogglUserResponse(await Raw.GetUserAsync());
    }

    /// <summary>
    /// Returns the preferences of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="TogglUserPreferencesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/preferences#get-preferences-for-the-current-user</cref>
    /// </see>
    public TogglUserPreferencesResponse GetUserPreferences() {
        return new TogglUserPreferencesResponse(Raw.GetUserPreferences());
    }

    /// <summary>
    /// Returns the preferences of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="TogglUserPreferencesResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://developers.track.toggl.com/docs/api/preferences#get-preferences-for-the-current-user</cref>
    /// </see>
    public async Task<TogglUserPreferencesResponse> GetUserPreferencesAsync() {
        return new TogglUserPreferencesResponse(await Raw.GetUserPreferencesAsync());
    }

    #endregion

}
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.User;

/// <summary>
/// Options describing a request for getting the last known location of authenticated user.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-users-last-known-location</cref>
/// </see>
public class TogglGetLocationOptions : TogglTrackHttpRequestOptions {

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        return HttpRequest.Get("/api/v9/me/location");
    }

    #endregion

}
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.User;

/// <summary>
/// Options describing a request for getting all organizations of the authenticated user.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-organizations-that-a-user-is-part-of</cref>
/// </see>
public class TogglGetOrganizationsOptions : TogglTrackHttpRequestOptions {

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        return HttpRequest.Get("/api/v9/me/organizations");
    }

    #endregion

}
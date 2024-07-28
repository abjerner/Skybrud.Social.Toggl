using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.User;

/// <summary>
/// Options describing a request for getting all features for the authenticated user.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-features</cref>
/// </see>
public class TogglGetFeaturesOptions : TogglTrackHttpRequestOptions {

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        return HttpRequest.Get("/api/v9/me/features");
    }

    #endregion

}
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Workspaces;

/// <summary>
/// Options describing a request for getting the workspaces of the authenticated user.
/// </summary>
public class TogglGetWorkspacesOptions : TogglTrackHttpRequestOptions {

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {
        return HttpRequest.Get("/api/v9/workspaces");
    }

    #endregion

}
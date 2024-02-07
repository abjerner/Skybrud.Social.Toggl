using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Toggl.Http;

/// <summary>
/// Options describing a request for the Toggl Track API.
/// </summary>
public abstract class TogglTrackHttpRequestOptions : IHttpRequestOptions {

    /// <summary>
    /// Returns a new <see cref="IHttpRequest"/> instance for this options instance.
    /// </summary>
    /// <returns>An instance of <see cref="IHttpRequest"/>.</returns>
    public abstract IHttpRequest GetRequest();

}
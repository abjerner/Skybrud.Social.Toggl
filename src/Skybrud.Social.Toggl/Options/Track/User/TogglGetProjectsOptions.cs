using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.User;

/// <summary>
/// Options describing a request for getting all projects of the authenticated user.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-projects</cref>
/// </see>
public class TogglGetProjectsOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets whether archived projects should be included in the response. Default is <see langword="false"/>.
    /// </summary>
    public bool IncludeArchived { get; set; }

    /// <summary>
    /// Gets or sets a timestamp. If set, only projects (including deleted ones) modified since this timestamp will be returned. Default is <see langword="null"/>.
    /// </summary>
    public EssentialsTime? Since { get; set; }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Initialize and populate thw query string
        IHttpQueryString query = new HttpQueryString();
        if (IncludeArchived) query.Add("include_archived", "true");
        if (Since is not null) query.Add("since", Since.UnixTimeSeconds);

        // Initialize a new request
        return HttpRequest.Get("/api/v9/me/projects");

    }

    #endregion

}
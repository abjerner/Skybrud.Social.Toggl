using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.User;

/// <summary>
/// Options describing a request for getting all clients of the authenticated user.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-clients</cref>
/// </see>
public class TogglGetClientsOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets a timestamp. If set, only clients created, modified or deleted since this timestamp will be returned. Default is <see langword="null"/>.
    /// </summary>
    public EssentialsTime? Since { get; set; }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Initialize and populate thw query string
        IHttpQueryString query = new HttpQueryString();
        if (Since is not null) query.Add("since", Since.UnixTimeSeconds);

        // Initialize a new request
        return HttpRequest.Get("/api/v9/me/clients");

    }

    #endregion

}
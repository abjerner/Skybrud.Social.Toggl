using Skybrud.Social.Toggl.Endpoints.Track;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Apis;

/// <summary>
/// Raw implementation of the <strong>Track</strong> API.
/// </summary>
public class TogglTrackRawApi {

    #region Properties

    /// <summary>
    /// Gets a reference to the HTTP client.
    /// </summary>
    public TogglHttpClient Client { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Clients</strong> endpoint.
    /// </summary>
    public TogglClientsRawEndpoint Clients { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Entries</strong> endpoint.
    /// </summary>
    public TogglEntriesRawEndpoint Entries { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Projects</strong> endpoint.
    /// </summary>
    public TogglProjectsRawEndpoint Projects { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Tags</strong> endpoint.
    /// </summary>
    public TogglTagsRawEndpoint Tags { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>User</strong> endpoint.
    /// </summary>
    public TogglUserRawEndpoint User { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Workspaces</strong> endpoint.
    /// </summary>
    public TogglWorkspacesRawEndpoint Workspaces { get; }

    #endregion

    #region Constructors

    internal TogglTrackRawApi(TogglHttpClient client) {
        Client = client;
        Clients = new TogglClientsRawEndpoint(client);
        Entries = new TogglEntriesRawEndpoint(client);
        Projects = new TogglProjectsRawEndpoint(client);
        Tags = new TogglTagsRawEndpoint(client);
        User = new TogglUserRawEndpoint(client);
        Workspaces = new TogglWorkspacesRawEndpoint(client);
    }

    #endregion

}
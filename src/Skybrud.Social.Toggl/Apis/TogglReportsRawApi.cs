using Skybrud.Social.Toggl.Endpoints.Reports;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Apis;

/// <summary>
/// Class representing the raw implementation of the <strong>Reports</strong> API.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/reports_start/</cref>
/// </see>
public class TogglReportsRawApi {

    #region Properties

    /// <summary>
    /// Gets a reference to the HTTP client.
    /// </summary>
    public TogglHttpClient Client { get; }

    /// <summary>
    /// Gets a reference to the raw <strong>Detailed reports</strong> endpoint.
    /// </summary>
    public TogglDetailedReportsRawEndpoint Detailed { get; }

    #endregion

    #region Constructors

    internal TogglReportsRawApi(TogglHttpClient client) {
        Client = client;
        Detailed = new TogglDetailedReportsRawEndpoint(client);
    }

    #endregion

}
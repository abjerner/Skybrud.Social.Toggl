using Skybrud.Social.Toggl.Endpoints.Reports;

namespace Skybrud.Social.Toggl.Apis;

/// <summary>
/// Implementation of the <strong>Reports</strong> API.
/// </summary>
public class TogglReportsApi {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the <strong>Detailed Reports</strong> endpoint.
    /// </summary>
    public TogglDetailedReportsEndpoint Detailed { get; }

    #endregion

    #region Constructors

    internal TogglReportsApi(TogglHttpService service) {
        Service = service;
        Detailed = new TogglDetailedReportsEndpoint(Service);
    }

    #endregion

}
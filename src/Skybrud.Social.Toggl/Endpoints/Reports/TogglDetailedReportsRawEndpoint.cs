using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Options.Reports.Detailed;

namespace Skybrud.Social.Toggl.Endpoints.Reports;

/// <summary>
/// Class representing the raw implementation of <strong>Detailed Reports</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/</cref>
/// </see>
public class TogglDetailedReportsRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the HTTP client.
    /// </summary>
    public TogglHttpClient Client { get; }

    #endregion

    #region Constructors

    internal TogglDetailedReportsRawEndpoint(TogglHttpClient client) {
        Client = client;
    }

    #endregion

    #region Member methods

    #region SearchTimeEntries(...)

    /// <summary>
    /// Returns time entries for detailed report according to the given filters.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public IHttpResponse Search(int workspaceId, EssentialsDate startDate, EssentialsDate endDate) {
        return Search(new TogglDetailedReportSearchOptions {
            WorkspaceId = workspaceId,
            StartDate = startDate,
            EndDate = endDate
        });
    }

    /// <summary>
    /// Returns time entries for detailed report according to the given filters.
    /// </summary>
    /// <param name="options">The options describing the request to the Reports API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public IHttpResponse Search(TogglDetailedReportSearchOptions options) {
        return Client.GetResponse(options);
    }

    #endregion

    #region SearchTimeEntriesAsync(...)

    /// <summary>
    /// Returns time entries for detailed report according to the given filters.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public async Task<IHttpResponse> SearchAsync(int workspaceId, EssentialsDate startDate, EssentialsDate endDate) {
        return await SearchAsync(new TogglDetailedReportSearchOptions {
            WorkspaceId = workspaceId,
            StartDate = startDate,
            EndDate = endDate
        });
    }

    /// <summary>
    /// Returns time entries for detailed report according to the given filters.
    /// </summary>
    /// <param name="options">The options describing the request to the Reports API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public async Task<IHttpResponse> SearchAsync(TogglDetailedReportSearchOptions options) {
        return await Client.GetResponseAsync(options);
    }

    #endregion

    #endregion

}
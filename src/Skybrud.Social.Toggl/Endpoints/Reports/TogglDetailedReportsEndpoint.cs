using System.Threading.Tasks;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Options.Reports.Detailed;
using Skybrud.Social.Toggl.Responses.Reports.Detailed;

namespace Skybrud.Social.Toggl.Endpoints.Reports;

/// <summary>
/// Class representing the implementation of the <strong>Detailed Reports</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/</cref>
/// </see>
public class TogglDetailedReportsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent service.
    /// </summary>
    public TogglHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public TogglDetailedReportsRawEndpoint Raw { get; }

    #endregion

    #region Constructors

    internal TogglDetailedReportsEndpoint(TogglHttpService service) {
        Service = service;
        Raw = service.Client.Reports.Detailed;
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
    /// <returns>An instance of <see cref="TogglDetailedReportSearchResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public TogglDetailedReportSearchResponse Search(int workspaceId, EssentialsDate startDate, EssentialsDate endDate) {
        return new TogglDetailedReportSearchResponse(Raw.Search(workspaceId, startDate, endDate));
    }

    /// <summary>
    /// Returns time entries for detailed report according to the given filters.
    /// </summary>
    /// <param name="options">The options describing the request to the Reports API.</param>
    /// <returns>An instance of <see cref="TogglDetailedReportSearchResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public TogglDetailedReportSearchResponse Search(TogglDetailedReportSearchOptions options) {
        return new TogglDetailedReportSearchResponse(Raw.Search(options));
    }

    #endregion

    #region SearchTimeEntriesAsync(...)

    /// <summary>
    /// Returns time entries for detailed report according to the given filters.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns>An instance of <see cref="TogglDetailedReportSearchResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public async Task<TogglDetailedReportSearchResponse> SearchAsync(int workspaceId, EssentialsDate startDate, EssentialsDate endDate) {
        return new TogglDetailedReportSearchResponse(await Raw.SearchAsync(workspaceId, startDate, endDate));
    }

    /// <summary>
    /// Returns time entries for detailed report according to the given filters.
    /// </summary>
    /// <param name="options">The options describing the request to the Reports API.</param>
    /// <returns>An instance of <see cref="TogglDetailedReportSearchResponse"/> representing the response from the Toggl API.</returns>
    /// <see>
    ///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
    /// </see>
    public async Task<TogglDetailedReportSearchResponse> SearchAsync(TogglDetailedReportSearchOptions options) {
        return new TogglDetailedReportSearchResponse(await Raw.SearchAsync(options));
    }

    #endregion

    #endregion

}
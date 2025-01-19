using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Reports.Detailed;

/// <summary>
/// Class representing a group in a detailed report.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
/// </see>
public class TogglDetailedReportTimeEntryGroup : TogglObject {

    /// <summary>
    /// Gets the ID of the project.
    /// </summary>
    public int? ProjectId { get; }

    /// <summary>
    /// Gets the name of the project.
    /// </summary>
    public string? ProjectName { get; }

    /// <summary>
    /// Gets the HEX color code of the project.
    /// </summary>
    public string? ProjectHex { get; }

    /// <summary>
    /// Gets the name of the client.
    /// </summary>
    public string? ClientName { get; }

    /// <summary>
    /// Gets the description of the entries in the group.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Gets the time entries of the group.
    /// </summary>
    public IReadOnlyList<TogglDetailedReportTimeEntry> TimeEntries { get; }

    /// <summary>
    /// Gets the combined duration of the time entries in the group.
    /// </summary>
    public TimeSpan Duration { get; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">A JSON object representing the group.</param>
    public TogglDetailedReportTimeEntryGroup(JObject json) : base(json) {
        ProjectId = json.GetInt32OrNull("project_id");
        ProjectName = json.GetString("project_name");
        ProjectHex = json.GetString("project_hex");
        ClientName = json.GetString("client_name");
        Description = json.GetString("description")!;
        TimeEntries = json.GetArrayItems("time_entries", x => new TogglDetailedReportTimeEntry(x, this));
        Duration = TimeSpan.FromSeconds(TimeEntries.Sum(x => x.Seconds));
    }

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> into an instance of <see cref="TogglDetailedReportTimeEntryGroup"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglDetailedReportTimeEntryGroup"/>.</returns>
    public static TogglDetailedReportTimeEntryGroup Parse(JObject json) {
        return new TogglDetailedReportTimeEntryGroup(json);
    }

    #endregion

}
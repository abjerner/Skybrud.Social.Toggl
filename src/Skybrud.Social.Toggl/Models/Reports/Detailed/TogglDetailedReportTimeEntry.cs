using System;
using System.Text;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Reports.Detailed;

/// <summary>
/// Class representing a time entry in a detailed report.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
/// </see>
public class TogglDetailedReportTimeEntry : TogglObject {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent group.
    /// </summary>
    public TogglDetailedReportTimeEntryGroup Group { get; }

    /// <summary>
    /// Gets the ID of the entry.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the duration as seconds.
    /// </summary>
    public long Seconds { get; }

    /// <summary>
    /// Gets the duration of the time entry.
    /// </summary>
    public TimeSpan Duration { get; }

    /// <summary>
    /// Gets a timestamp for when the time entry started.
    /// </summary>
    public EssentialsTime Start { get; }

    /// <summary>
    /// Gets a timestamp for when the time entry stopped.
    /// </summary>
    public EssentialsTime Stop { get; }

    /// <summary>
    /// Gets a timestamp for when the time entry was added.
    /// </summary>
    public EssentialsTime At { get; }

    /// <summary>
    /// Gets the ID of the project, or <see langword="null"/> if not added to a project.
    /// </summary>
    public int? ProjectId => Group.ProjectId;

    /// <summary>
    /// Gets the description.
    /// </summary>
    public string Description => Group.Description;

    #endregion

    #region Constructors

    internal TogglDetailedReportTimeEntry(JObject json, TogglDetailedReportTimeEntryGroup group) : base(json) {
        Group = group;
        Id = json.GetInt64("id");
        Seconds = json.GetInt64("seconds");
        Duration = TimeSpan.FromSeconds(Seconds);
        Start = json.GetString("start", ParseIso8601Timestamp)!;
        Stop = json.GetString("stop", ParseIso8601Timestamp)!;
        At = json.GetString("at", ParseIso8601Timestamp)!;
    }

    #endregion

}
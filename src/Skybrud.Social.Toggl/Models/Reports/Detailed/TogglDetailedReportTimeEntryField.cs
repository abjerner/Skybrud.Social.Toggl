#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.Toggl.Models.Reports.Detailed;

/// <summary>
/// Enum class representing a field of a time entry.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/reports/detailed_reports/#post-search-time-entries</cref>
/// </see>
public enum TogglDetailedReportTimeEntryField {
    Date,
    User,
    Duration,
    Description,
    LastUpdate
}
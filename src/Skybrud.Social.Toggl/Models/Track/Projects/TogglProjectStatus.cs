#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.Toggl.Models.Track.Projects;

/// <summary>
/// Enum class representing the status of a <see cref="TogglProject"/>.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/projects/#get-workspaceproject</cref>
/// </see>
public enum TogglProjectStatus {
    Active,
    Archived,
    Deleted,
    Ended,
    Upcoming
}
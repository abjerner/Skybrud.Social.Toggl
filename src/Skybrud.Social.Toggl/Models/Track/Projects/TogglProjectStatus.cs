#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.Toggl.Models.Track.Projects;

/// <summary>
/// Enum class representing the status of a <see cref="TogglProject"/>.
/// </summary>
/// <remarks>
/// A project will generally always have a status, but when creating a project, a status isn't specified in the
/// returned project. IIRC this hasn't always been the case (╯‵□′)╯︵┻━┻
///
/// If the status isn't specified for a <see cref="TogglProject"/>, the <see cref="TogglProject.Status"/> property is
/// set to <see cref="Unspecified"/>.
/// </remarks>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/projects/#get-workspaceproject</cref>
/// </see>
public enum TogglProjectStatus {
    Unspecified,
    Active,
    Archived,
    Deleted,
    Ended,
    Upcoming
}
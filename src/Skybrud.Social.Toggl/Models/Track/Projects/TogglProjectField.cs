namespace Skybrud.Social.Toggl.Models.Track.Projects;

/// <summary>
/// Enum class indicating a project field - e.g. to sort by.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/projects/#get-workspaceprojects</cref>
/// </see>
/// <remarks>
/// The API documentation only describes that a <c>sort_field</c> parameter exists, but doesn't describe the possible values.
/// </remarks>
public enum TogglProjectField {

    /// <summary>
    /// Indicates that projects should be sorted by their name.
    /// </summary>
    ProjectName

}
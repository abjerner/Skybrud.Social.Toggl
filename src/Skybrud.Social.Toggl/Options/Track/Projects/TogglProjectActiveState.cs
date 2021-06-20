namespace Skybrud.Social.Toggl.Options.Track.Projects {
    
    /// <summary>
    /// Enum class representing the active state of projects that should be returned.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
    /// </see>
    public enum TogglProjectActiveState {

        /// <summary>
        /// Indicates that only active projects should be returned.
        /// </summary>
        True,

        /// <summary>
        /// Indicates that only archived projects should be returned.
        /// </summary>
        False,

        /// <summary>
        /// Indicates that both active and archived projects should be returned.
        /// </summary>
        Both

    }

}
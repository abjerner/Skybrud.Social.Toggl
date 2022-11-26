namespace Skybrud.Social.Toggl.Models.Track {

    /// <summary>
    /// Enum class indicating the format by which durations should be rendered.
    /// </summary>
    public enum TogglDurationFormat {

        /// <summary>
        /// Indicates that durations should be rendered using a <strong>classic</strong> format - eg. <c>47:06 min</c>.
        /// </summary>
        Classic,

        /// <summary>
        /// Indicates that durations should be rendered using an <strong>improved</strong> format - eg. <c>0:47:06</c>.
        /// </summary>
        Improved,

        /// <summary>
        /// Indicates that durations should be rendered using a <strong>decimal</strong> format - eg. <c>0.79 h</c>.
        /// </summary>
        Decimal

    }

}
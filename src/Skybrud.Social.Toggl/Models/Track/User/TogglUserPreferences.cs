using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.Toggl.Models.Track.User;

/// <summary>
/// Class representing the preferences of a Toggl user.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/preferences#get-preferences-for-the-current-user</cref>
/// </see>
public class TogglUserPreferences : JsonObjectBase {

    #region Properties

    /// <summary>
    /// Gets or sets the format by which dates should be rendered.
    /// </summary>
    public string DateFormat { get; }

    /// <summary>
    /// Gets or sets the format by which time should be rendered.
    /// </summary>
    public string TimeOfDayFormat { get; }

    /// <summary>
    /// Gets or sets the format by durations dates should be rendered.
    /// </summary>
    public TogglDurationFormat DurationFormat { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the project.</param>
    protected TogglUserPreferences(JObject json) : base(json) {
        DateFormat = json.GetString("date_format")!;
        TimeOfDayFormat = json.GetString("timeofday_format")!;
        DurationFormat = json.GetEnum<TogglDurationFormat>("duration_format");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> into an instance of <see cref="TogglUserPreferences"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglUserPreferences"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static TogglUserPreferences? Parse(JObject? json) {
        return json == null ? null : new TogglUserPreferences(json);
    }

    #endregion

}
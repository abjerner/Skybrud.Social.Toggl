using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Track.User;

#pragma warning disable CS1591

/// <summary>
/// Class representing a user features.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-features</cref>
/// </see>
public class TogglUserFeature : TogglObject {

    #region Properties

    public bool IsEnabled { get; }

    public int FeatureId { get; }

    public string Name { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the workspace.</param>
    protected TogglUserFeature(JObject json) : base(json) {
        IsEnabled = json.GetBoolean("enabled");
        FeatureId = json.GetInt32("feature_id");
        Name = json.GetString("name")!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglUserFeature"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglUserFeature"/>.</returns>
    [return: NotNullIfNotNull(nameof(json))]
    public static TogglUserFeature? Parse(JObject? json) {
        return json == null ? null : new TogglUserFeature(json);
    }

    #endregion

}
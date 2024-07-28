using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.Toggl.Models.Track.User;

/// <summary>
/// Class representing a list of user features.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-features</cref>
/// </see>
public class TogglUserFeatureList : TogglObject {

    #region Properties

    public IReadOnlyList<TogglUserFeature> Features { get; }

    public int WorkspaceId { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the workspace.</param>
    protected TogglUserFeatureList(JObject json) : base(json) {
        Features = json.GetArrayItems("features", TogglUserFeature.Parse);
        WorkspaceId = json.GetInt32("workspace_id");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglUserFeatureList"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglUserFeatureList"/>.</returns>
    [return: NotNullIfNotNull(nameof(json))]
    public static TogglUserFeatureList? Parse(JObject? json) {
        return json == null ? null : new TogglUserFeatureList(json);
    }

    #endregion

}
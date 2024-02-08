using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Models.Track.Workspaces;

namespace Skybrud.Social.Toggl.Models.Track.Tags;

/// <summary>
/// Class representing a Toggl tag.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/tags</cref>
/// </see>
public class TogglTag : TogglObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the parent workspace.
    /// </summary>
    public int WorkspaceId { get; }

    /// <summary>
    /// Gets the ID of the tag.
    /// </summary>
    public int TagId { get; }

    /// <summary>
    /// Gets the name of the workspace.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets a timestamp that indicates the time workspace was last updated.
    /// </summary>
    public EssentialsTime At { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the tag.</param>
    protected TogglTag(JObject json) : base(json) {
        WorkspaceId = json.GetInt32("workspace_id");
        TagId = json.GetInt32("id");
        Name = json.GetString("name")!;
        At = json.GetString("at", EssentialsTime.FromIso8601)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglWorkspace"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglWorkspace"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static TogglTag? Parse(JObject? json) {
        return json == null ? null : new TogglTag(json);
    }

    #endregion

}
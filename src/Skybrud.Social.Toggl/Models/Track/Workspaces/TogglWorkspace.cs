using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Track.Workspaces;

/// <summary>
/// Class representing a Toggl workspace.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/workspaces</cref>
/// </see>
public class TogglWorkspace : TogglObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the workspace.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the name of the workspace.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets whether it's a pro workspace or not. Shows if someone is paying for the workspace or not.
    /// </summary>
    public bool IsPremium { get; }

    /// <summary>
    /// Gets whether the currently requesting user has admin access to the workspace.
    /// </summary>
    public bool IsAdmin { get; }

    /// <summary>
    /// Gets a timestamp that indicates the time workspace was last updated.
    /// </summary>
    public EssentialsTime At { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the workspace.</param>
    protected TogglWorkspace(JObject json) : base(json) {
        Id = json.GetInt32("id");
        Name = json.GetString("name")!;
        IsPremium = json.GetBoolean("premium");
        IsAdmin = json.GetBoolean("admin");
        // TODO: Add support for "default_hourly_rate" property
        // TODO: Add support for "default_currency" property
        // TODO: Add support for "only_admins_may_create_projects" property
        // TODO: Add support for "only_admins_see_billable_rates" property
        // TODO: Add support for "rounding" property
        // TODO: Add support for "rounding_minutes" property
        At = json.GetString("at", EssentialsTime.FromIso8601)!;
        // TODO: Add support for "logo_url" property
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglWorkspace"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglWorkspace"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static TogglWorkspace? Parse(JObject? json) {
        return json == null ? null : new TogglWorkspace(json);
    }

    #endregion

}
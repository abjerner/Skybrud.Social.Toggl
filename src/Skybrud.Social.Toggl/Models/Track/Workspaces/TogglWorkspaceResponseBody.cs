using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Track.Workspaces;

/// <summary>
/// Class representing the response body of a single Toggl workspace.
/// </summary>
/// <see>
///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md</cref>
/// </see>
public class TogglWorkspaceResponseBody : JsonObjectBase {

    #region Properties

    /// <summary>
    /// Gets a reference to the workspace of the response.
    /// </summary>
    public TogglWorkspace Data { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
    protected TogglWorkspaceResponseBody(JObject json) : base(json) {
        Data = json.GetObject("data", TogglWorkspace.Parse)!;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglWorkspaceResponseBody"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglWorkspaceResponseBody"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static TogglWorkspaceResponseBody? Parse(JObject? json) {
        return json == null ? null : new TogglWorkspaceResponseBody(json);
    }

    #endregion

}
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Track.Projects;

/// <summary>
/// Class representing the response body of a single Toggl project.
/// </summary>
/// <see>
///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#get-project-data</cref>
/// </see>
public class TogglProjectResponseBody : JsonObjectBase {

    #region Properties

    /// <summary>
    /// Gets a reference to the project of the response.
    /// </summary>
    public TogglProject Data { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
    protected TogglProjectResponseBody(JObject json) : base(json) {
        Data = json.GetObject("data", TogglProject.Parse)!;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglProjectResponseBody"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglProjectResponseBody"/>.</returns>
    [return: NotNullIfNotNull("json")]
    public static TogglProjectResponseBody? Parse(JObject? json) {
        return json == null ? null : new TogglProjectResponseBody(json);
    }

    #endregion

}
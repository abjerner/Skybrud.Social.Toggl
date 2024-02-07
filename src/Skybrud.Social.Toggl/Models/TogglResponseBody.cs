using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.Toggl.Models;

/// <summary>
/// Class representing a response body received from the Toggl API.
/// </summary>
public class TogglResponseBody : JsonObjectBase {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the response body.</param>
    protected TogglResponseBody(JObject json) : base(json) { }

}
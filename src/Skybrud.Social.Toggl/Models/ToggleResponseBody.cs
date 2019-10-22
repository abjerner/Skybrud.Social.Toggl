using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Toggl.Models {

    /// <summary>
    /// Class representing a response body received from the Toggl API.
    /// </summary>
    public class ToggleResponseBody : JsonObjectBase {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the response body.</param>
        protected ToggleResponseBody(JObject obj) : base(obj) { }

    }

}
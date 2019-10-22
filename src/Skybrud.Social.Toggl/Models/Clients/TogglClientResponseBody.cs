using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Toggl.Models.Clients {

    /// <summary>
    /// Class representing the response body of a single Toggl client.
    /// </summary>
    /// <see>
    ///     <cref>hhttps://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-details</cref>
    /// </see>
    public class TogglClientResponseBody : ToggleResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to the time entry of the response.
        /// </summary>
        public TogglClient Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected TogglClientResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", TogglClient.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglClientResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglClientResponseBody"/>.</returns>
        public static TogglClientResponseBody Parse(JObject obj) {
            return obj == null ? null : new TogglClientResponseBody(obj);
        }

        #endregion

    }

}
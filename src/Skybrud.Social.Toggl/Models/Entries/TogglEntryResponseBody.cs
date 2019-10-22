using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Toggl.Models.Entries {

    /// <summary>
    /// Class representing the response body of a single Toggl time entry.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entry-details</cref>
    /// </see>
    public class TogglEntryResponseBody : ToggleResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to the time entry of the response.
        /// </summary>
        public TogglEntry Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected TogglEntryResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", TogglEntry.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglEntryResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglEntryResponseBody"/>.</returns>
        public static TogglEntryResponseBody Parse(JObject obj) {
            return obj == null ? null : new TogglEntryResponseBody(obj);
        }

        #endregion

    }

}
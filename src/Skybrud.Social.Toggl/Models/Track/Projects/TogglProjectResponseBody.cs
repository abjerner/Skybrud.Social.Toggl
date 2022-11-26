using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Track.Projects {

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
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected TogglProjectResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", TogglProject.Parse)!;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglProjectResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglProjectResponseBody"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static TogglProjectResponseBody? Parse(JObject? obj) {
            return obj == null ? null : new TogglProjectResponseBody(obj);
        }

        #endregion

    }

}
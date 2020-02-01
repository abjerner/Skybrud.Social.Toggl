using Newtonsoft.Json;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Toggl.Options.Projects {
    
    /// <summary>
    /// Options for a request to get information about a single Toggl project.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#get-project-data</cref>
    /// </see>
    public class TogglGetProjectOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the project.
        /// </summary>
        [JsonIgnore]
        public int Id { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        public TogglGetProjectOptions(int projectId) {
            Id = projectId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            if (Id == 0) throw new PropertyNotSetException(nameof(Id));
            return new HttpRequest(HttpMethod.Get, "/api/v8/projects/" + Id);
        }

        #endregion

    }

}
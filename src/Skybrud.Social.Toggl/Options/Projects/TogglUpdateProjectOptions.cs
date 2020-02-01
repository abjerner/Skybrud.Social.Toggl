using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Models.Projects;

namespace Skybrud.Social.Toggl.Options.Projects {

    /// <summary>
    /// Options for a request to update an existing Toggl project.
    /// </summary>
    public class TogglUpdateProjectOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets the ID of the project.
        /// </summary>
        [JsonIgnore]
        public int Id { get; }

        /// <summary>
        /// Gets or sets the new name of the project.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the new client ID of the project.
        /// </summary>
        [JsonProperty("cid")]
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets whether the project is active.
        /// </summary>
        [JsonProperty("active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the new color of the project.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from an existing <paramref name="project"/>.
        /// </summary>
        /// <param name="project">The project to be updated.</param>
        public TogglUpdateProjectOptions(TogglProject project) {
            Id = project.Id;
            ClientId = project.ClientId;
            Name = project.Name;
            IsActive = project.IsActive;
            Color = project.Color.ToString();
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            JObject body = new JObject {
                {"project", JObject.FromObject(this)}
            };

            return new HttpRequest(HttpMethod.Put, "/api/v8/projects/" + Id, body);

        }

        #endregion

    }

}
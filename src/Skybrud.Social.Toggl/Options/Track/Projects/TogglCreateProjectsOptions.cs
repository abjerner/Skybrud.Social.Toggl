using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Contants;

namespace Skybrud.Social.Toggl.Options.Track.Projects {

    /// <summary>
    /// Options for request to create a new Toggl project.
    /// </summary>
    public class TogglCreateProjectsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the name of the project to be created.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets or sets the ID of the workspace to which the project should be added.
        /// </summary>
        [JsonProperty("wid")]
        public int WorkspaceId { get; }

        /// <summary>
        /// Gets or sets the ID of the client to which the project should be added. If <c>0</c> (default), the project will not be added to a client.
        /// </summary>
        [JsonProperty("cid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ClientId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TogglCreateProjectsOptions"/> based on the specified <paramref name="name"/> and <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="name">The name of the project.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        public TogglCreateProjectsOptions(string name, int workspaceId) {
            Name = name;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TogglCreateProjectsOptions"/> based on the specified <paramref name="name"/> and <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="name">The name of the project.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <param name="clientId">The ID of the parent client.</param>
        public TogglCreateProjectsOptions(string name, int workspaceId, int clientId) {
            Name = name;
            WorkspaceId = workspaceId;
            ClientId = clientId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));
            if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));

            JObject body = new JObject {
                { "project", JObject.FromObject(this) }
            };

            return HttpRequest.Post($"https://{TogglConstants.Track.HostName}/api/v8/projects", body);

        }

        #endregion

    }

}
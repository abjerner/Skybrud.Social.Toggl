using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Contants;

namespace Skybrud.Social.Toggl.Options.Track.Clients {

    /// <summary>
    /// Options for request to create a new Toggl client.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client</cref>
    /// </see>
    public class TogglCreateClientOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the name of the client to be created.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Gets or sets the ID of the workspace to which the client should be added.
        /// </summary>
        [JsonProperty("wid")]
        public int WorkspaceId { get; }

        /// <summary>
        /// Gets or sets the notes of the client.
        /// </summary>
        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TogglCreateClientOptions"/> based on the specified <paramref name="name"/> and <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        public TogglCreateClientOptions(string name, int workspaceId) {
            Name = name;
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TogglCreateClientOptions"/> based on the specified <paramref name="name"/> and <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="name">The name of the client.</param>
        /// <param name="workspaceId">The ID of the parent workspace.</param>
        /// <param name="notes">Notes for the client.</param>
        public TogglCreateClientOptions(string name, int workspaceId, string notes) {
            Name = name;
            WorkspaceId = workspaceId;
            Notes = notes;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));
            if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));

            JObject body = new () {
                {"client",  JObject.FromObject(this)}
            };

            return HttpRequest.Post($"https://{TogglConstants.Track.HostName}/api/v8/clients", body);

        }

        #endregion

    }

}
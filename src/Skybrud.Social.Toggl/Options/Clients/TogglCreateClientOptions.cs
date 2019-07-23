﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Clients {

    /// <summary>
    /// Options for request to create a new Toggl client.
    /// </summary>
    public class TogglCreateClientOptions : IHttpPostOptions<JObject> {

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
        public string GetUrl() {
            return "/api/v8/clients";
        }

        /// <inheritdoc />
        public IHttpQueryString GetQueryString() {
            return null;
        }

        /// <inheritdoc />
        public JObject GetBody() {
            if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));
            if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
            return JObject.FromObject(this);
        }

        #endregion

    }

}
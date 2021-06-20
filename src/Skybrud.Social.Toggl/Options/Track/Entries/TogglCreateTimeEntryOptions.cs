using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Contants;

namespace Skybrud.Social.Toggl.Options.Track.Entries {

    /// <summary>
    /// Options for request to create a new Toggl time entry.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#create-a-time-entry</cref>
    /// </see>
    public class TogglCreateTimeEntryOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the description of the entry.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the ID of the workspace to which the client should be added.
        /// </summary>
        [JsonProperty("wid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the project the time entry should be added to.
        /// </summary>
        [JsonProperty("pid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the task the time entry should be added to.
        /// </summary>
        [JsonProperty("tid", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the start time of the entry.
        /// </summary>
        [JsonProperty("start")]
        public EssentialsTime Start { get; set; }

        /// <summary>
        /// Gets or sets the duration of the entry.
        /// </summary>
        [JsonProperty("duration")]
        [JsonConverter(typeof(TimeSpanSecondsConverter))]
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Gets or sets the name of your client app used for accessing the Toggl API. If not specified, this property will fallback to <c>Skybrud.Social</c>.
        /// </summary>
        [JsonProperty("created_with")]
        public string CreatedWith { get; set; }

        /// <summary>
        /// Gets or sets an array of tags of the time entry.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get; set; }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            JObject entry = JObject.FromObject(this);
            if (entry.HasValue("created_with") == false) entry["created_with"] = "Skybrud.Social";

            JObject body = new JObject {
                {"time_entry",  entry}
            };

            return HttpRequest.Post($"https://{TogglConstants.Track.HostName}/api/v8/time_entries", body);

        }

        #endregion

    }

}
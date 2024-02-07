using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Entries;

/// <summary>
/// Options for request to create a new Toggl time entry.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/time_entries#post-timeentries</cref>
/// </see>
public class TogglCreateTimeEntryOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the workspace.
    /// </summary>
    [JsonProperty("workspace_id")]
    public int WorkspaceId { get; set; }

    /// <summary>
    /// Gets or sets the description of the entry.
    /// </summary>
    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the ID of the project the time entry should be added to.
    /// </summary>
    [JsonProperty("project_id", NullValueHandling = NullValueHandling.Ignore)]
    public int? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the task the time entry should be added to.
    /// </summary>
    [JsonProperty("task_id", NullValueHandling = NullValueHandling.Ignore)]
    public int? TaskId { get; set; }

    /// <summary>
    /// Gets or sets the start time of the entry.
    /// </summary>
    [JsonProperty("start")]
    public EssentialsTime? Start { get; set; }

    /// <summary>
    /// Gets or sets the stop time of the entry.
    /// </summary>
    [JsonProperty("stop", NullValueHandling = NullValueHandling.Ignore)]
    public EssentialsTime? Stop { get; set; }

    /// <summary>
    /// Gets or sets the duration of the entry.
    /// </summary>
    [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(TimeSpanSecondsConverter))]
    public TimeSpan? Duration { get; set; }

    /// <summary>
    /// Gets or sets the name of your client app used for accessing the Toggl API. If not specified, this property will fallback to <c>Skybrud.Social</c>.
    /// </summary>
    [JsonProperty("created_with")]
    public string? CreatedWith { get; set; }

    /// <summary>
    /// Gets or sets an array of tags of the time entry.
    /// </summary>
    [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Tags { get; set; } = new();

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        if (Start == null) throw new PropertyNotSetException(nameof(Start));

        JObject body = JObject.FromObject(this);
        if (body.HasValue("created_with") == false) body["created_with"] = "Skybrud.Social";

        return HttpRequest.Post($"/api/v9/workspaces/{WorkspaceId}/time_entries", body);

    }

    #endregion

}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Clients;

/// <summary>
/// Options describing a request for creating a new Toggl client.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients#post-create-client</cref>
/// </see>
public class TogglCreateClientOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the workspace to which the client should be added.
    /// </summary>
    [JsonProperty("wid")]
    public int WorkspaceId { get; set; }

    /// <summary>
    /// Gets or sets the name of the client to be created.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="TogglCreateClientOptions"/> based on the specified <paramref name="workspaceId"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="name">The name of the client.</param>
    public TogglCreateClientOptions(int workspaceId, string name) {
        WorkspaceId = workspaceId;
        Name = name;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Input validation
        if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));
        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));

        // Serialize the response body
        JObject body = JObject.FromObject(this);

        // Initialize a new POST request
        return HttpRequest.Post($"/api/v9/workspaces/{WorkspaceId}/clients", body);

    }

    #endregion

}
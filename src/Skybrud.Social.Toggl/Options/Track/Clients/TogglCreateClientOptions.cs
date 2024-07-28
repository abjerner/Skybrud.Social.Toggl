using System.Diagnostics.CodeAnalysis;
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
#if NET8_0_OR_GREATER
    public required int WorkspaceId { get; set; }
#else
    public int WorkspaceId { get; set; }
#endif

    /// <summary>
    /// Gets or sets the name of the client to be created.
    /// </summary>
    [JsonProperty("name")]
#if NET8_0_OR_GREATER
    public required string Name { get; set; }
#else
    public string? Name { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglCreateClientOptions() { }

    /// <summary>
    /// Initializes a new instance of <see cref="TogglCreateClientOptions"/> based on the specified <paramref name="workspaceId"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="name">The name of the client.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
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
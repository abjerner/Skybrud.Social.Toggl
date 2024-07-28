using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Options.Track.Clients;

/// <summary>
/// Options describing a request for updating an existing Toggl client.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/clients#put-change-client</cref>
/// </see>
public class TogglUpdateClientOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the parent workspace.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int WorkspaceId { get; set; }
#else
    public int WorkspaceId { get; set; }
#endif

    /// <summary>
    /// Gets the ID of the client.
    /// </summary>
#if NET8_0_OR_GREATER
    public required int ClientId { get; set; }
#else
    public int ClientId { get; set; }
#endif

    /// <summary>
    /// Gets or sets the new name of the client.
    /// </summary>
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
    public TogglUpdateClientOptions() { }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="workspaceId"/>, <paramref name="clientId"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the client to be updated.</param>
    /// <param name="name">The new name of the client.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public TogglUpdateClientOptions(int workspaceId, int clientId, string name) {
        WorkspaceId = workspaceId;
        ClientId = clientId;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance from an existing <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be updated.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public TogglUpdateClientOptions(TogglClient client) {
        WorkspaceId = client.WorkspaceId;
        ClientId = client.Id;
        Name = client.Name;
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="client"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="client">The client to be updated.</param>
    /// <param name="name">The new name of the client.</param>
#if NET8_0_OR_GREATER
    [SetsRequiredMembers]
#endif
    public TogglUpdateClientOptions(TogglClient client, string name) {
        WorkspaceId = client.WorkspaceId;
        ClientId = client.Id;
        Name = name;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

        JObject body = new () {
            {"wid", WorkspaceId},
            {"name", Name}
        };

        return HttpRequest.Put($"/api/v9/workspaces/{WorkspaceId}/clients/{ClientId}", body);

    }

    #endregion

}
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Options.Track.Projects;

/// <summary>
/// Options for request to create a new Toggl project.
/// </summary>
public class TogglCreateProjectOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the workspace to which the project should be added.
    /// </summary>
    public int WorkspaceId { get; }

    /// <summary>
    /// Gets or sets the ID of the client to which the project should be added. If <see langword="null"/> (default), the project will not be added to a client.
    /// </summary>
    public int? ClientId { get; }

    /// <summary>
    /// Gets or sets the name of the project to be created.
    /// </summary>
    public string Name { get; }

    // TODO: add support for additional properties

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of <see cref="TogglCreateProjectOptions"/> based on the specified <paramref name="workspaceId"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="name">The name of the project.</param>
    public TogglCreateProjectOptions(int workspaceId, string name) {
        WorkspaceId = workspaceId;
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="TogglCreateProjectOptions"/> based on the specified <paramref name="workspaceId"/>, <paramref name="clientId"/> and <paramref name="name"/>.
    /// </summary>
    /// <param name="workspaceId">The ID of the parent workspace.</param>
    /// <param name="clientId">The ID of the parent client.</param>
    /// <param name="name">The name of the project.</param>
    public TogglCreateProjectOptions(int workspaceId, int clientId, string name) {
        WorkspaceId = workspaceId;
        ClientId = clientId;
        Name = name;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
        if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

        JObject body = new () {
            {"name", Name}
        };

        if (ClientId > 0) body.Add("client_id", ClientId);

        return HttpRequest.Post($"/api/v9/workspaces/{WorkspaceId}/projects", body);

    }

    #endregion

}
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;
using Skybrud.Social.Toggl.Models.Track.Projects;

namespace Skybrud.Social.Toggl.Options.Track.Projects;

/// <summary>
/// Options describing a request for updating a Toggl project.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/projects#put-workspaceproject</cref>
/// </see>
public class TogglUpdateProjectOptions : TogglTrackHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the parent workspace.
    /// </summary>
    [JsonIgnore]
    public int WorkspaceId { get; set; }

    /// <summary>
    /// Gets the ID of the project.
    /// </summary>
    [JsonIgnore]
    public int ProjectId { get; }

    /// <summary>
    /// Gets or sets the new name of the project.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the new client ID of the project.
    /// </summary>
    [JsonProperty("client_id")]
    public int? ClientId { get; set; }

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
        ProjectId = project.Id;
        ClientId = project.ClientId;
        Name = project.Name;
        IsActive = project.IsActive;
        Color = project.Color;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public override IHttpRequest GetRequest() {

        // Input validation
        if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
        if (ProjectId == 0) throw new PropertyNotSetException(nameof(ProjectId));

        // Serialize the request body
        JObject body = JObject.FromObject(this);

        // Initialize a new PUT request
        return HttpRequest.Put($"/api/v9/workspaces/{WorkspaceId}/projects/{ProjectId}", body);

    }

    #endregion

}
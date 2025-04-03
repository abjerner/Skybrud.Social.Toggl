using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Exceptions;

namespace Skybrud.Social.Toggl.Models.Track.Projects;

/// <summary>
/// Class representing a Toggl project.
/// </summary>
/// <see>
///     <cref>https://developers.track.toggl.com/docs/api/projects</cref>
/// </see>
public class TogglProject : TogglObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the project.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets the ID of workspace the project belongs to.
    /// </summary>
    public int WorkspaceId { get; }

    /// <summary>
    /// Gets the ID of client the project belongs to.
    /// </summary>
    public int? ClientId { get; }

    /// <summary>
    /// Gets the name of the project.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets whether the project is billable.
    /// </summary>
    public bool IsBillable { get; }

    /// <summary>
    /// Gets whether project is accessible for only project users or for all workspace users.
    /// </summary>
    public bool IsPrivate { get; }

    /// <summary>
    /// Gets whether the project is currently active (opposed to being archived).
    /// </summary>
    public bool IsActive { get; }

    /// <summary>
    /// Gets whether the project can be used as a template.
    /// </summary>
    public bool IsTemplate { get; }

    /// <summary>
    /// Gets a timestamp for when the project was last updated.
    /// </summary>
    public EssentialsTime At { get; }

    /// <summary>
    /// Gets a timestamp for when the project was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets the HEX color code selected for the project.
    /// </summary>
    public string Color { get; }

    /// <summary>
    /// whether the estimated hours are automatically calculated based on task estimations or manually fixed based
    /// on the value of <c>estimated_hours</c>.
    /// </summary>
    public bool AutoEstimates { get; }

    /// <summary>
    /// <em>Not documented in the Toggl API Documentation.</em>
    /// </summary>
    public bool ActualHours { get; }

    /// <summary>
    /// Gets the status of the project.
    /// </summary>
    /// <remarks>
    /// If the project is returned following a request to create the project, the Toggl API may not specify a status
    /// for the project, in which case the value of this property will be <see cref="TogglProjectStatus.Unspecified"/>.
    /// </remarks>
    public TogglProjectStatus Status { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the project.</param>
    protected TogglProject(JObject json) : base(json) {
        try {
            Id = json.GetInt32("id");
            WorkspaceId = json.GetInt32("workspace_id");
            ClientId = json.GetInt32OrNull("client_id");
            Name = json.GetString("name")!;
            IsBillable = json.GetBoolean("billable");
            IsPrivate = json.GetBoolean("private");
            IsActive = json.GetBoolean("active");
            IsTemplate = json.GetBoolean("template");
            At = json.GetString("at", EssentialsTime.FromIso8601)!;
            CreatedAt = json.GetString("created_at", EssentialsTime.FromIso8601)!;
            Color = json.GetString("color")!;
            AutoEstimates = json.GetBoolean("auto_estimates");
            ActualHours = json.GetBoolean("actual_hours");
            Status = json.GetString("status", ParseStatus);
        } catch (Exception ex) {
            throw new TogglJsonParseException(json, "Failed parsing project from JSON.", ex);
        }
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglProject"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglProject"/>.</returns>
    [return: NotNullIfNotNull(nameof(json))]
    public static TogglProject? Parse(JObject? json) {
        return json == null ? null : new TogglProject(json);
    }

    private static TogglProjectStatus ParseStatus(string value) {
        return string.IsNullOrWhiteSpace(value) ? TogglProjectStatus.Unspecified : EnumUtils.ParseEnum<TogglProjectStatus>(value);
    }

    #endregion

}
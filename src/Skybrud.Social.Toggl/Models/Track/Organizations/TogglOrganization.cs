using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Track.Organizations;

/// <summary>
/// Class representing a Toggl organizations.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/organizations</cref>
/// </see>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-organizations-that-a-user-is-part-of</cref>
/// </see>
public class TogglOrganization : TogglObject {

    #region Properties

    /// <summary>
    /// Gets a timestamp that indicates the time the organizations was last updated.
    /// </summary>
    public EssentialsTime At { get; }

    /// <summary>
    /// Gets a timestamp that indicates when the organization was created,
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets the ID of the workspace.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets whether the authenticated user is an admin of the organization.
    /// </summary>
    public bool IsAdmin { get; }

    /// <summary>
    /// Gets whether the organization option <c>is_multi_workspace_enabled</c> is set.
    /// </summary>
    public bool IsMultiWorkspaceEnabled { get; }

    /// <summary>
    /// Gets whether the authenticated user is the owner of the organization.
    /// </summary>
    public bool IsOwner { get; }

    /// <summary>
    /// Not documented by Toggl.
    /// </summary>
    public bool IsUnified { get; }

    /// <summary>
    /// Gets the maximum number of workspaces allowed for the organization.
    /// </summary>
    public int MaxWorkspaces { get; }

    /// <summary>
    /// Gets the name of the organization.
    /// </summary>
    public string Name { get; }

    // TODO: Add support for "permissions" property

    /// <summary>
    /// Gets whether the subscription plan is an enterprise plan.
    /// </summary>
    public bool PricingPlanEnterprise { get; }

    /// <summary>
    /// Gets the ID of the organization plan.
    /// </summary>
    public int PricingPlanId { get; }

    /// <summary>
    /// Gets the subscription plan name the org is currently on. <c>Free</c> or any plan name coming from payment provider.
    /// </summary>
    public string PricingPlanName { get; }

    // TODO: Add support for "suspended_at" property
    // TODO: Add support for "trial_info" property

    /// <summary>
    /// Gets the amount of users in the organization.
    /// </summary>
    public int UserCount { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the workspace.</param>
    protected TogglOrganization(JObject json) : base(json) {
        At = json.GetString("at", ParseIso8601Timestamp)!;
        CreatedAt = json.GetString("created_at", ParseIso8601Timestamp)!;
        Id = json.GetInt32("id");
        IsAdmin = json.GetBoolean("admin");
        IsMultiWorkspaceEnabled = json.GetBoolean("is_multi_workspace_enabled");
        IsOwner = json.GetBoolean("owner");
        IsUnified = json.GetBoolean("is_unified");
        MaxWorkspaces = json.GetInt32("max_workspaces");
        Name = json.GetString("name")!;
        // TODO: Add support for "permissions" property
        PricingPlanEnterprise = json.GetBoolean("pricing_plan_enterprise");
        PricingPlanId = json.GetInt32("pricing_plan_id");
        PricingPlanName = json.GetString("pricing_plan_name")!;
        // TODO: Add support for "suspended_at" property
        // TODO: Add support for "trial_info" property
        UserCount = json.GetInt32("user_count");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglOrganization"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglOrganization"/>.</returns>
    [return: NotNullIfNotNull(nameof(json))]
    public static TogglOrganization? Parse(JObject? json) {
        return json == null ? null : new TogglOrganization(json);
    }

    #endregion

}
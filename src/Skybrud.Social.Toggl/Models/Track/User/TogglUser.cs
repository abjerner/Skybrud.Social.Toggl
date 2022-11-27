using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Track.User {

    /// <summary>
    /// Class with information about the authenticated user.
    /// </summary>
    public class TogglUser : TogglObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the API token, or <see langword="null"/> if not available.
        /// </summary>
        public string? ApiToken { get; }

        /// <summary>
        /// Gets the email address of the user.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the full name of the user.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Gets the time zone of the user - eg. <c>Europe/Copenhagen</c>.
        /// </summary>
        public string TimeZone { get; }

        /// <summary>
        /// Gets the ID of the user's default workspace.
        /// </summary>
        public int DefaultWorkspaceId { get; }

        /// <summary>
        /// Gets the day the user has selected as the beginning of the week.
        /// </summary>
        public DayOfWeek BeginningOfWeek { get; }

        /// <summary>
        /// Gets the URL to the user's profile picture.
        /// </summary>
        public string ImageUrl { get; }

        /// <summary>
        /// Gets a timestamp for when the user was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the user was last updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the project.</param>
        protected TogglUser(JObject json) : base(json) {
            Id = json.GetInt32("id");
            ApiToken = json.GetString("api_token");
            Email = json.GetString("email")!;
            FullName = json.GetString("fullname")!;
            TimeZone = json.GetString("timezone")!;
            DefaultWorkspaceId = json.GetInt32("default_workspace_id");
            BeginningOfWeek = json.GetInt32("beginning_of_week", x => (DayOfWeek) x);
            ImageUrl = json.GetString("image_url")!;
            CreatedAt = json.GetString("created_at", ParseIso8601Timestamp)!;
            UpdatedAt = json.GetString("updated_at", ParseIso8601Timestamp)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="TogglUser"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglUser"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static TogglUser? Parse(JObject? json) {
            return json == null ? null : new TogglUser(json);
        }

        #endregion

    }

}
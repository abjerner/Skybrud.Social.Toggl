using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Track.Workspaces {

    /// <summary>
    /// Class representing a Toggl workspace.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md</cref>
    /// </see>
    public class TogglWorkspace : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets the ID of the workspace.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the name of the workspace.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets whether it's a pro workspace or not. Shows if someone is paying for the workspace or not.
        /// </summary>
        public bool IsPremium { get; }

        /// <summary>
        /// Gets whether the currently requesting user has admin access to the workspace.
        /// </summary>
        public bool IsAdmin { get; }

        /// <summary>
        /// Gets a timestamp that indicates the time workspace was last updated.
        /// </summary>
        public EssentialsTime At { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the project.</param>
        protected TogglWorkspace(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Name = obj.GetString("name");
            IsPremium = obj.GetBoolean("premium");
            IsAdmin = obj.GetBoolean("admin");
            // TODO: Add support for "default_hourly_rate" property
            // TODO: Add support for "default_currency" property
            // TODO: Add support for "only_admins_may_create_projects" property
            // TODO: Add support for "only_admins_see_billable_rates" property
            // TODO: Add support for "rounding" property
            // TODO: Add support for "rounding_minutes" property
            At = obj.GetString("at", EssentialsTime.FromIso8601);
            // TODO: Add support for "logo_url" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglWorkspace"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglWorkspace"/>.</returns>
        public static TogglWorkspace Parse(JObject obj) {
            return obj == null ? null : new TogglWorkspace(obj);
        }

        #endregion

    }

}
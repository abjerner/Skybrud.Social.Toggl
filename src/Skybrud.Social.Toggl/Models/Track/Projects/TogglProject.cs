using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Track.Projects {
    
    /// <summary>
    /// Class representing a Toggl project.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md</cref>
    /// </see>
    public class TogglProject : JsonObjectBase {

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
        public int ClientId { get; }

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
        /// Gets the a timestamp for when the project was last updated.
        /// </summary>
        public EssentialsTime At { get; }

        /// <summary>
        /// Gets a timestamp for when the project was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets the ID of the color selected for the project.
        /// </summary>
        public int Color { get; }

        /// <summary>
        /// whether the estimated hours are automatically calculated based on task estimations or manually fixed based
        /// on the value of <c>estimated_hours</c>.
        /// </summary>
        public bool AutoEstimates { get; }

        /// <summary>
        /// <em>Not documentated in the Toggl API Documentation.</em>
        /// </summary>
        public bool ActualHours { get; }

        /// <summary>
        /// <em>Not documentated in the Toggl API Documentation.</em>
        /// </summary>
        public string HexColor { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the project.</param>
        protected TogglProject(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            WorkspaceId = obj.GetInt32("wid");
            ClientId = obj.GetInt32("cid");
            Name = obj.GetString("name");
            IsBillable = obj.GetBoolean("billable");
            IsPrivate = obj.GetBoolean("private");
            IsActive = obj.GetBoolean("active");
            IsTemplate = obj.GetBoolean("template");
            At = obj.GetString("at", EssentialsTime.Parse);
            CreatedAt = obj.GetString("created_at", EssentialsTime.Parse);
            Color = obj.GetInt32("color");
            AutoEstimates = obj.GetBoolean("auto_estimates");
            ActualHours = obj.GetBoolean("actual_hours");
            HexColor = obj.GetString("hex_color");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglProject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglProject"/>.</returns>
        public static TogglProject Parse(JObject obj) {
            return obj == null ? null : new TogglProject(obj);
        }

        #endregion

    }

}
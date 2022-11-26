using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Track.Clients {

    /// <summary>
    /// Class representing a Toggl client.
    /// </summary>
    public class TogglClient : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets the ID of the client.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the ID of the workspace the client belongs to.
        /// </summary>
        public int WorkspaceId { get; }

        /// <summary>
        /// Gets the name of the client.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets a timestamp for when the client was last updated.
        /// </summary>
        public EssentialsTime At { get; }

        /// <summary>
        /// Gets the notes of the client.
        /// </summary>
        public string? Notes { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the client.</param>
        protected TogglClient(JObject json) : base(json) {
            Id = json.GetInt32("id");
            WorkspaceId = json.GetInt32("wid");
            Name = json.GetString("name")!;
            At = json.GetString("at", EssentialsTime.Parse)!;
            Notes = json.GetString("notes");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglClient"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglClient"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static TogglClient? Parse(JObject? json) {
            return json == null ? null : new TogglClient(json);
        }

        #endregion

    }

}
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
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the client.</param>
        protected TogglClient(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            WorkspaceId = obj.GetInt32("wid");
            Name = obj.GetString("name")!;
            At = obj.GetString("at", EssentialsTime.Parse)!;
            Notes = obj.GetString("notes");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglClient"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglClient"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static TogglClient? Parse(JObject? obj) {
            return obj == null ? null : new TogglClient(obj);
        }

        #endregion

    }

}
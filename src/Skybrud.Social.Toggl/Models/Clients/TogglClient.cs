using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Clients {

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
        /// Gets a timestamp for when the client was added.
        /// </summary>
        public EssentialsTime At { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the client.</param>
        protected TogglClient(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            WorkspaceId = obj.GetInt32("wid");
            Name = obj.GetString("name");
            At = obj.GetString("at", EssentialsTime.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglClient"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglClient"/>.</returns>
        public static TogglClient Parse(JObject obj) {
            return obj == null ? null : new TogglClient(obj);
        }

        #endregion

    }

}
using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Entries {

    /// <summary>
    /// Class representing a Toggl entry.
    /// </summary>
    public class TogglEntry : JsonObjectBase {

        #region Properties

        public int Id { get; }

        public Guid Guid { get; }

        public int Wid { get; }

        public int Pid { get; }

        public bool IsBillable { get; }

        public EssentialsTime Start { get; }

        public EssentialsTime Stop { get; }

        public TimeSpan Duration { get; }

        public string Description { get; }

        public bool Duronly { get; }

        public EssentialsTime At { get; }

        public int Uid { get; }

        public string[] Tags { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the entry.</param>
        protected TogglEntry(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Guid = obj.GetGuid("guid");
            Wid = obj.GetInt32("wid");
            Pid = obj.GetInt32("pid");
            IsBillable = obj.GetBoolean("billable");
            Start = obj.GetString("start", EssentialsTime.Parse);
            Stop = obj.GetString("stop", EssentialsTime.Parse);
            Duration = obj.GetDouble("duration", TimeSpan.FromSeconds);
            Description = obj.GetString("description");
            Duronly = obj.GetBoolean("duronly");
            At = obj.GetString("at", EssentialsTime.Parse);
            Uid = obj.GetInt32("uid");
            Tags = obj.GetStringArray("tags");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglEntry"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglEntry"/>.</returns>
        public static TogglEntry Parse(JObject obj) {
            return obj == null ? null : new TogglEntry(obj);
        }

        #endregion

    }

}
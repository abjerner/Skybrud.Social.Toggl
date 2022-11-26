using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Track.Entries {

    /// <summary>
    /// Class representing a Toggl time entry.
    /// </summary>
    public class TogglEntry : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets the ID of the time entry.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the <see cref="System.Guid"/> ID of the time entry.
        /// </summary>
        public Guid Guid { get; }

        /// <summary>
        /// Gets the ID of the parent workspace.
        /// </summary>
        public int WorkspaceId { get; }

        /// <summary>
        /// Gets the ID of the parent project.
        /// </summary>
        public int ProjectId { get; }

        /// <summary>
        /// Gets whether the time entry has been added to a project.
        /// </summary>
        public bool HasProjectId => ProjectId > 0;

        /// <summary>
        /// Gets the ID of the task of the time entry.
        /// </summary>
        public int TaskId { get; }

        /// <summary>
        /// Gets whether the time entry has been added to a task.
        /// </summary>
        public bool HasTaskId => TaskId > 0;

        /// <summary>
        /// Gets whether the time entry is billable.
        /// </summary>
        public bool IsBillable { get; }

        /// <summary>
        /// Gets a timestamp representing the start time of the time entry.
        /// </summary>
        public EssentialsTime Start { get; }

        /// <summary>
        /// Gets a timestamp representing the stop time of the time entry.
        /// </summary>
        public EssentialsTime? Stop { get; }

        /// <summary>
        /// Gets the duration of the time entry.
        /// </summary>
        public TimeSpan Duration { get; }

        /// <summary>
        /// Gets the description of the time entry.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the time entry only specifies duration.
        /// </summary>
        public bool DurationOnly { get; }

        /// <summary>
        /// Gets a timestamp for when the time entry was last updated.
        /// </summary>
        public EssentialsTime At { get; }

        /// <summary>
        /// Gets the ID of the user behind the time entry.
        /// </summary>
        public int UserId { get; }

        /// <summary>
        /// Gets an array with the tags added to the time entry.
        /// </summary>
        public IReadOnlyList<string> Tags { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the entry.</param>
        protected TogglEntry(JObject json) : base(json) {
            Id = json.GetInt64("id");
            Guid = json.GetGuid("guid");
            WorkspaceId = json.GetInt32("wid");
            ProjectId = json.GetInt32("pid");
            TaskId = json.GetInt32("tid");
            IsBillable = json.GetBoolean("billable");
            Start = json.GetString("start", EssentialsTime.Parse)!;
            Stop = json.GetString("stop", EssentialsTime.Parse);
            Duration = json.GetDouble("duration", TimeSpan.FromSeconds);
            Description = json.GetString("description")!;
            DurationOnly = json.GetBoolean("duronly");
            At = json.GetString("at", EssentialsTime.Parse)!;
            UserId = json.GetInt32("uid");
            Tags = json.GetStringArray("tags");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglEntry"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglEntry"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static TogglEntry? Parse(JObject? json) {
            return json == null ? null : new TogglEntry(json);
        }

        #endregion

    }

}
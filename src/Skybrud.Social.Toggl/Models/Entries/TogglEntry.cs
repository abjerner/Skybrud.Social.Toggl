using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Entries {

    public class TogglEntry : JsonObjectBase {

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

        public static TogglEntry Parse(JObject obj) {
            return obj == null ? null : new TogglEntry(obj);
        }

    }

}
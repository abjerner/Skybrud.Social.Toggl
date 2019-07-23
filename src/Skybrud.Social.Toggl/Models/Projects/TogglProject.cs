using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Projects {

    public class TogglProject : JsonObjectBase {

        public int Id { get; }

        public int Wid { get; }

        public int Cid { get; }

        public string Name { get; }

        public bool IsBillable { get; }

        public bool IsPrivate { get; }

        public bool IsActive { get; }

        public bool IsTemplate { get; }

        public EssentialsTime At { get; }

        public EssentialsTime CreatedAt { get; }

        public int Color { get; }

        public bool AutoEstimates { get; }

        public bool ActualHours { get; }

        public string HexColor { get; }

        protected TogglProject(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Wid = obj.GetInt32("wid");
            Cid = obj.GetInt32("cid");
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

        public static TogglProject Parse(JObject obj) {
            return obj == null ? null : new TogglProject(obj);
        }

    }

}
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Toggl.Models.Clients {

    public class TogglClient : JsonObjectBase {

        public int Id { get; }

        public int Wid { get; }

        public string Name { get; }

        public EssentialsTime At { get; }

        protected TogglClient(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Wid = obj.GetInt32("wid");
            Name = obj.GetString("name");
            At = obj.GetString("at", EssentialsTime.Parse);
        }

        public static TogglClient Parse(JObject obj) {
            return obj == null ? null : new TogglClient(obj);
        }

    }

}
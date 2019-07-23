using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Toggl.Models.Clients {

    public class TogglCreateClientBody : JsonObjectBase {

        public TogglClient Data { get; }

        protected TogglCreateClientBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", TogglClient.Parse);
        }

        public static TogglCreateClientBody Parse(JObject obj) {
            return obj == null ? null : new TogglCreateClientBody(obj);
        }

    }

}
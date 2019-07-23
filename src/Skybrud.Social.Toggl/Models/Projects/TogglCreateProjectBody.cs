using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Toggl.Models.Projects {

    public class TogglCreateProjectBody : JsonObjectBase {

        #region Properties

        public TogglProject Data { get; }

        #endregion

        #region Constructors

        protected TogglCreateProjectBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", TogglProject.Parse);
        }
        
        #endregion

        #region Constructors

        public static TogglCreateProjectBody Parse(JObject obj) {
            return obj == null ? null : new TogglCreateProjectBody(obj);
        }

        #endregion

    }

}
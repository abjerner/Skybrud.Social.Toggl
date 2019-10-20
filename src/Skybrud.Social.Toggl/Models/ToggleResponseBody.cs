using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Toggl.Models {

    /// <summary>
    /// Class representing a response body received from the Toggl API.
    /// </summary>
    public class ToggleResponseBody : JsonObjectBase {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the response body.</param>
        protected ToggleResponseBody(JObject obj) : base(obj) { }

    }

    /// <summary>
    /// Class representing a response body received from the Toggl API.
    /// </summary>
    public class ToggleResponseBody<T> : ToggleResponseBody {

        #region Properties

        /// <summary>
        /// Gets the <c>data</c> part of the response body.
        /// </summary>
        public T Data { get; }

        #endregion

        #region Constructors

        protected ToggleResponseBody(JObject obj, Func<JObject,T> data) : base(obj) {
            Data = obj.GetObject("data", data);
        }

        #endregion

    }

}
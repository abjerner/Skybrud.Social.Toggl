﻿using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Track.Clients {

    /// <summary>
    /// Class representing the response body of a single Toggl client.
    /// </summary>
    /// <see>
    ///     <cref>hhttps://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-details</cref>
    /// </see>
    public class TogglClientResponseBody : TogglResponseBody {

        #region Properties

        /// <summary>
        /// Gets a reference to the time entry of the response.
        /// </summary>
        public TogglClient Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">An instance of <see cref="JObject"/> representing the object.</param>
        protected TogglClientResponseBody(JObject json) : base(json) {
            Data = json.GetObject("data", TogglClient.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglClientResponseBody"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglClientResponseBody"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static TogglClientResponseBody? Parse(JObject? json) {
            return json == null ? null : new TogglClientResponseBody(json);
        }

        #endregion

    }

}
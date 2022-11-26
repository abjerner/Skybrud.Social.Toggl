﻿using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Toggl.Models.Track.Workspaces {

    /// <summary>
    /// Class representing the response body of a single Toggl workspace.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md</cref>
    /// </see>
    public class TogglWorkspaceResponseBody : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets a reference to the workspace of the response.
        /// </summary>
        public TogglWorkspace Data { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">An instance of <see cref="JObject"/> representing the object.</param>
        protected TogglWorkspaceResponseBody(JObject obj) : base(obj) {
            Data = obj.GetObject("data", TogglWorkspace.Parse);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TogglWorkspaceResponseBody"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TogglWorkspaceResponseBody"/>.</returns>
        public static TogglWorkspaceResponseBody Parse(JObject obj) {
            return obj == null ? null : new TogglWorkspaceResponseBody(obj);
        }

        #endregion

    }

}
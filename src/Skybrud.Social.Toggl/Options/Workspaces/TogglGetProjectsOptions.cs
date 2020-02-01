using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.Toggl.Options.Projects;

namespace Skybrud.Social.Toggl.Options.Workspaces {
    
    /// <summary>
    /// Options for a request to the projects of a workspace.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects</cref>
    /// </see>
    public class TogglGetProjectsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the workspace.
        /// </summary>
        public int WorkspaceId { get; set; }

        /// <summary>
        /// Gets or sets the active state that the returned projects should match. Default is <see cref="TogglProjectActiveState.True"/>.
        /// </summary>
        public TogglProjectActiveState Active { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TogglGetProjectsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        public TogglGetProjectsOptions(int workspaceId) {
            WorkspaceId = workspaceId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <param name="active">The active state that the returned projects should match.</param>
        public TogglGetProjectsOptions(int workspaceId, TogglProjectActiveState active) {
            WorkspaceId = workspaceId;
            Active = active;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            if (WorkspaceId == 0) throw new PropertyNotSetException(nameof(WorkspaceId));
            
            return HttpRequest.Get($"/api/v8/workspaces/{WorkspaceId}/projects", new HttpQueryString {
                {"active", Active.ToLower()}
            });

        }

        #endregion

    }

}
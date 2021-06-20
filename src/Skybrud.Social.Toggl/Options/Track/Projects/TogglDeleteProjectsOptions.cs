using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Contants;
using Skybrud.Social.Toggl.Models.Track.Projects;

namespace Skybrud.Social.Toggl.Options.Track.Projects {

    /// <summary>
    /// Options for a request to delete multiple Toggl projects.
    /// </summary>
    public class TogglDeleteProjectsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets a list with the IDs of the projects to be deleted.
        /// </summary>
        public List<int> Ids { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TogglDeleteProjectsOptions() {
            Ids = new List<int>();
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project to be deleted.</param>
        public TogglDeleteProjectsOptions(int projectId) {
            Ids = new List<int>(projectId);
        }

        /// <summary>
        /// Initializes a new instance from an existing <paramref name="project"/>.
        /// </summary>
        /// <param name="project">The project to be deleted.</param>
        public TogglDeleteProjectsOptions(TogglProject project) {
            if (project == null) throw new ArgumentNullException(nameof(project));
            Ids = new List<int>(project.Id);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="projectIds"/>.
        /// </summary>
        /// <param name="projectIds">The IDs of the projects to be deleted.</param>
        public TogglDeleteProjectsOptions(params int[] projectIds) {
            if (projectIds == null) throw new ArgumentNullException(nameof(projectIds));
            Ids = new List<int>(projectIds);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="projectIds"/>.
        /// </summary>
        /// <param name="projectIds">The IDs of the projects to be deleted.</param>
        public TogglDeleteProjectsOptions(IEnumerable<int> projectIds) {
            if (projectIds == null) throw new ArgumentNullException(nameof(projectIds));
            Ids = new List<int>(projectIds);
        }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="projects"/>.
        /// </summary>
        /// <param name="projects">The projects to be deleted.</param>
        public TogglDeleteProjectsOptions(params TogglProject[] projects) {
            if (projects == null) throw new ArgumentNullException(nameof(projects));
            Ids = new List<int>(projects.Select(x => x.Id));
        }

        /// <summary>
        /// Initializes a new instance from athe specified <paramref name="projects"/>.
        /// </summary>
        /// <param name="projects">The projects to be deleted.</param>
        public TogglDeleteProjectsOptions(IEnumerable<TogglProject> projects) {
            if (projects == null) throw new ArgumentNullException(nameof(projects));
            Ids = new List<int>(projects.Select(x => x.Id));
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            if (Ids == null || Ids.Count == 0) throw new PropertyNotSetException(nameof(Ids));
            return HttpRequest.Delete($"https://{TogglConstants.Track.HostName}/api/v8/projects/{string.Join(",", Ids)}");
        }

        #endregion

    }

}
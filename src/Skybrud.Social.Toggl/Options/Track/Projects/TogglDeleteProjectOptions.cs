using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Contants;
using Skybrud.Social.Toggl.Models.Track.Projects;

namespace Skybrud.Social.Toggl.Options.Track.Projects {

    /// <summary>
    /// Options for a request to delete a Toggl project.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project</cref>
    /// </see>
    public class TogglDeleteProjectOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the project to be deleted.
        /// </summary>
        public int Id { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TogglDeleteProjectOptions() { }

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="projectId"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project to be deleted.</param>
        public TogglDeleteProjectOptions(int projectId) {
            Id = projectId;
        }

        /// <summary>
        /// Initializes a new instance from an existing <paramref name="project"/>.
        /// </summary>
        /// <param name="project">The project to be deleted.</param>
        public TogglDeleteProjectOptions(TogglProject project) {
            Id = project.Id;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            if (Id == 0) throw new PropertyNotSetException(nameof(Id));
            return HttpRequest.Delete($"https://{TogglConstants.Track.HostName}/api/v8/projects/{Id}");
        }

        #endregion

    }

}
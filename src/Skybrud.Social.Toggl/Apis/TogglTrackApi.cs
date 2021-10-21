using Skybrud.Social.Toggl.Endpoints.Track;

namespace Skybrud.Social.Toggl.Apis {
    
    /// <summary>
    /// Implementation of the <strong>Track</strong> API.
    /// </summary>
    public class TogglTrackApi {
        
        #region Properties

        /// <summary>
        /// Gets a reference to the parent service.
        /// </summary>
        public TogglHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the <strong>Clients</strong> endpoint.
        /// </summary>
        public TogglClientsEndpoint Clients { get; }

        /// <summary>
        /// Gets a reference to the <strong>Entries</strong> endpoint.
        /// </summary>
        public TogglEntriesEndpoint Entries { get; }

        /// <summary>
        /// Gets a reference to the <strong>Projects</strong> endpoint.
        /// </summary>
        public TogglProjectsEndpoint Projects { get; }

        /// <summary>
        /// Gets a reference to the <strong>Workspaces</strong> endpoint.
        /// </summary>
        public TogglWorkspacesEndpoint Workspaces { get; }

        #endregion

        #region Constructors

        internal TogglTrackApi(TogglHttpService service) {
            Service = service;
            Clients = new TogglClientsEndpoint(service);
            Entries = new TogglEntriesEndpoint(service);
            Projects = new TogglProjectsEndpoint(service);
            Workspaces = new TogglWorkspacesEndpoint(service);
        }

        #endregion

    }

}
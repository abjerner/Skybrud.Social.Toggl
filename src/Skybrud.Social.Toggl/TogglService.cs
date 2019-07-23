using System;
using Skybrud.Social.Toggl.Endpoints;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl {

    public class TogglService {

        #region Properties

        public TogglHttpClient Client { get; set; }

        public TogglClientsEndpoint Clients { get; }

        public TogglProjectsEndpoint Projects { get; }

        #endregion

        #region Constructors

        private TogglService(TogglHttpClient client) {
            Client = client;
            Clients = new TogglClientsEndpoint(this);
            Projects = new TogglProjectsEndpoint(this);
        }

        #endregion

        #region Static methods

        public static TogglService CreateFromClient(TogglHttpClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new TogglService(client);
        }

        public static TogglService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new TogglService(new TogglHttpClient(accessToken));
        }

        #endregion

    }

}
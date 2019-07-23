using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Endpoints.Raw {

    public class TogglProjectsRawEndpoint {

        #region Properties

        public TogglHttpClient Client { get; }

        #endregion

        #region Constructors

        public TogglProjectsRawEndpoint(TogglHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods
        
        public IHttpResponse CreateProject(string name, int workspaceId) {
            return CreateProject(name, workspaceId, 0);
        }

        public IHttpResponse CreateProject(string name, int workspaceId, int clientId) {

            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            JObject project = new JObject {
                {"name", name},
                {"wid", workspaceId}
            };

            if (clientId > 0) project.Add("cid", clientId);

            JObject body = new JObject {
                {"project", project}
            };

            return Client.DoHttpPostRequest("/api/v8/projects", body);

        }

        public IHttpResponse GetProjects(int workspaceId) {
            return Client.DoHttpGetRequest("/api/v8/workspaces/" + workspaceId + "/projects");
        }

        #endregion

    }

}
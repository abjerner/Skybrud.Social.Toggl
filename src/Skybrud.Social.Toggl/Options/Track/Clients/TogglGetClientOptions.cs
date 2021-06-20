using Newtonsoft.Json;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Contants;

namespace Skybrud.Social.Toggl.Options.Track.Clients {

    /// <summary>
    /// Options for a request to get information about a single Toggl client.
    /// </summary>
    /// <see>
    ///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-details</cref>
    /// </see>
    public class TogglGetClientOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the client.
        /// </summary>
        [JsonIgnore]
        public int Id { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="clientId"/>.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        public TogglGetClientOptions(int clientId) {
            Id = clientId;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {
            if (Id == 0) throw new PropertyNotSetException(nameof(Id));
            return HttpRequest.Get($"https://{TogglConstants.Track.HostName}/api/v8/clients/{Id}");
        }

        #endregion

    }

}
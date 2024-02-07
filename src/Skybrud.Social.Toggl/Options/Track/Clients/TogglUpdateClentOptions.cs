using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Toggl.Contants;
using Skybrud.Social.Toggl.Models.Track.Clients;

namespace Skybrud.Social.Toggl.Options.Track.Clients;

/// <summary>
/// Options for a request to update an existing Toggl client.
/// </summary>
/// <see>
///     <cref>https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client</cref>
/// </see>
public class TogglUpdateClentOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets the ID of the client.
    /// </summary>
    [JsonIgnore]
    public int Id { get; }

    /// <summary>
    /// Gets or sets the new name of the client.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the new notes of the client.
    /// </summary>
    [JsonProperty("notes")]
    public string? Notes { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from an existing <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The client to be updated.</param>
    public TogglUpdateClentOptions(TogglClient client) {
        Id = client.Id;
        Name = client.Name;
        Notes = client.Notes;
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    public IHttpRequest GetRequest() {

        if (string.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException(nameof(Name));

        JObject body = new () {
            {"client", JObject.FromObject(this)}
        };

        return HttpRequest.Put($"https://{TogglConstants.Track.HostName}/api/v8/clients/{Id}", body);

    }

    #endregion

}
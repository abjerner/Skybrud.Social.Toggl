using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Security;
using Skybrud.Social.Toggl.Apis;
using Skybrud.Social.Toggl.Contants;

namespace Skybrud.Social.Toggl.Http;

/// <summary>
/// Class for handling the HTTP communication with the Toggl API.
/// </summary>
public class TogglHttpClient : HttpClient {

    #region Properties

    /// <summary>
    /// Gets or sets the API token.
    /// </summary>
    public string? ApiToken { get; set; }

    /// <summary>
    /// Gets a reference to the raw <strong>Track</strong> API.
    /// </summary>
    public TogglTrackRawApi Track { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public TogglHttpClient() {
        Track = new TogglTrackRawApi(this);
    }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="apiToken"/>.
    /// </summary>
    /// <param name="apiToken">The access token to be used.</param>
    public TogglHttpClient(string apiToken) {
        ApiToken = apiToken;
        Track = new TogglTrackRawApi(this);
    }

    #endregion

    #region Member methods

    /// <inheritdoc />
    protected override void PrepareHttpRequest(IHttpRequest request) {
        if (string.IsNullOrWhiteSpace(ApiToken) == false) request.Authorization = $"Basic {SecurityUtils.Base64Encode($"{ApiToken}:api_token")}";
    }

    /// <summary>
    /// Returns the response of the request identified by the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public override IHttpResponse GetResponse(IHttpRequestOptions options) {

        // Get the request based on the options
        IHttpRequest request = options.GetRequest();

        // Append the scheme and host if not already present
        switch (options) {
            case TogglTrackHttpRequestOptions:
                if (request.Url.StartsWith("/")) request.Url = $"https://{TogglConstants.Track.HostName}{request.Url}";
                break;
        }

        // Prepare the request
        PrepareHttpRequest(request);

        // Send the request to the API and return the response
        return request.GetResponse();

    }

    #endregion

}
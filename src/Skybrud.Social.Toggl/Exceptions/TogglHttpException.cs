using System.Diagnostics.CodeAnalysis;
using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.Toggl.Exceptions;

/// <summary>
/// Class representing an exception/error returned by the Toggl API.
/// </summary>
public class TogglHttpException : TogglException, IHttpException {

    #region Properties

    /// <summary>
    /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
    /// </summary>
    public IHttpResponse Response { get; }

    /// <summary>
    /// Gets the HTTP status code returned by the Toggl API.
    /// </summary>
    public HttpStatusCode StatusCode => Response.StatusCode;

    /// <summary>
    /// Gets the error message returned by the Toggl API, if any.
    /// </summary>
    public string? Error { get; }

    /// <summary>
    /// Gets whether the response specified an error message.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Error))]
    public bool HasError => !string.IsNullOrWhiteSpace(Error);

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new exception based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public TogglHttpException(IHttpResponse response) : base($"Invalid response received from the Toggl API (status: {(int) response.StatusCode})") {
        Response = response;
        if (!response.ContentType.StartsWith("application/json")) return;
        if (!JsonUtils.TryParseJsonToken(response.Body, out JToken? token)) return;
        Error = token.Type switch {
            JTokenType.String => token.ToString(),
            _ => null
        };
    }

    #endregion

}
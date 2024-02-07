using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Exceptions;

namespace Skybrud.Social.Toggl.Responses;

/// <summary>
/// Class representing a response from the Toggl API.
/// </summary>
public class TogglResponse : HttpResponseBase {

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public TogglResponse(IHttpResponse response) : base(response) {
        if (response.StatusCode == HttpStatusCode.OK) return;
        if (response.StatusCode == HttpStatusCode.Created) return;
        throw new TogglHttpException(response);
    }

}

/// <summary>
/// Class representing a response from the Toggl API.
/// </summary>
public class TogglResponse<T> : TogglResponse {

    /// <summary>
    /// Gets the body of the response.
    /// </summary>
    public T Body { get; protected set; }

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="response"/>.
    /// </summary>
    /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
    public TogglResponse(IHttpResponse response) : base(response) {
        Body = default!;
    }

}
using System;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Toggl.Exceptions;

/// <summary>
/// Exception class indicating that parsing a <see cref="JObject"/> into a model for the Toggl implementation failed.
/// </summary>
public class TogglObjectParseException : TogglParseException<JToken> {

    /// <summary>
    /// Initializes a new instance based on the specified JSON <paramref name="value"/> and <paramref name="message"/>.
    /// </summary>
    /// <param name="value">The JSON value that could not be parsed.</param>
    /// <param name="message">The exception message.</param>
    public TogglObjectParseException(JToken value, string message) : base(value, message) { }

    /// <summary>
    /// Initializes a new instance based on the specified JSON <paramref name="value"/> and <paramref name="message"/>.
    /// </summary>
    /// <param name="value">The value that could not be parsed.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception, if any.</param>
    public TogglObjectParseException(JToken value, string message, Exception? innerException) : base(value, message, innerException) { }

}
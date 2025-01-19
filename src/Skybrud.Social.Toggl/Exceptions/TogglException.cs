using System;

namespace Skybrud.Social.Toggl.Exceptions;

/// <summary>
/// Class representing a basic Toggl exception.
/// </summary>
public class TogglException : Exception {

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public TogglException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/> and <paramref name="innerException"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception, if any.</param>
    public TogglException(string message, Exception? innerException) : base(message, innerException) { }

}
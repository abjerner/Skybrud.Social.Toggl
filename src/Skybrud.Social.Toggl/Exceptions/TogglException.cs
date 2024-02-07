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

}
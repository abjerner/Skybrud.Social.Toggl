using System;

namespace Skybrud.Social.Toggl.Exceptions;

/// <summary>
/// Exception class indicating that parsing related to the Toggl implementation failed.
/// </summary>
public class TogglParseException : TogglException {

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    public TogglParseException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception, if any.</param>
    public TogglParseException(string message, Exception? innerException) : base(message, innerException) { }

}

/// <summary>
/// Exception class indicating that parsing related to the Toggl implementation failed.
/// </summary>
public class TogglParseException<TValue> : TogglParseException where TValue : notnull {

    /// <summary>
    /// Gets a reference to the value that could not be parsed.
    /// </summary>
    public TValue Value { get; }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="value">The value that could not be parsed.</param>
    /// <param name="message">The message of the exception.</param>
    public TogglParseException(TValue value, string message) : base(message) {
        Value = value;
    }

    /// <summary>
    /// Initializes a new exception with the specified <paramref name="message"/>.
    /// </summary>
    /// <param name="value">The value that could not be parsed.</param>
    /// <param name="message">The message of the exception.</param>
    /// <param name="innerException">The inner exception, if any.</param>
    public TogglParseException(TValue value, string message, Exception? innerException) : base(message, innerException) {
        Value = value;
    }

}
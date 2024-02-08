using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Time;

#pragma warning disable CS1591

namespace Skybrud.Social.Toggl.Models;

public class TogglObject : JsonObjectBase {

    private static readonly string[] _formats = {
        "yyyy-MM-ddTHH\\:mm\\:ss.ffffffZ",
        "yyyy-MM-ddTHH\\:mm\\:ss.fffffZ",
        "yyyy-MM-ddTHH\\:mm\\:ss.ffffZ",
        "yyyy-MM-ddTHH\\:mm\\:ss.fffZ",
        "yyyy-MM-ddTHH\\:mm\\:ss.ffZ",
        "yyyy-MM-ddTHH\\:mm\\:ss.fZ"
    };

    #region Properties

    /// <summary>
    /// Gets the internal <see cref="Newtonsoft.Json.Linq.JObject"/> the object was created from.
    /// </summary>
    [JsonIgnore]
    public new JObject JObject => base.JObject!;

    #endregion

    #region Constructors

    protected TogglObject(JObject json) : base(json) { }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified ISO 8601 <paramref name="timestamp"/> into a corresponding instance of <see cref="EssentialsTime"/>.
    /// </summary>
    /// <param name="timestamp">The ISO 8601 timestamp.</param>
    /// <returns>An instance of <see cref="EssentialsTime"/>.</returns>
    /// <remarks>
    ///     <para>
    ///         Timestamps returned by the V9 API includes microseconds, whereas the V8 only includes
    ///         milliseconds. The V9 API however doesn't include trailing zeros, so the method checks a few
    ///         different formats (ISO 8601 timestamp formats with different precision).
    ///     </para>
    /// </remarks>
    [return: NotNullIfNotNull("timestamp")]
    protected static EssentialsTime? ParseIso8601Timestamp(string? timestamp) {
        if (timestamp == null) return null;
        return DateTimeOffset.ParseExact(timestamp, _formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
    }

    #endregion

}
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Strings;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.Toggl.Models.Track.User;

/// <summary>
/// Class representing a user location.
/// </summary>
/// <see>
///     <cref>https://engineering.toggl.com/docs/api/me#get-users-last-known-location</cref>
/// </see>
public class TogglUserLocation : TogglObject {

    #region Properties

    public string City { get; }

    public double CityLat { get; }

    public double CityLong { get; }

    public string CityLatLong { get; }

    public string CountryCode { get; }

    public string CountryName { get; }

    public string State { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">An instance of <see cref="JObject"/> representing the workspace.</param>
    protected TogglUserLocation(JObject json) : base(json) {
        City = json.GetString("city")!;
        CityLatLong = json.GetString("city_lat_long")!;
        CountryCode = json.GetString("country_code")!;
        CountryName = json.GetString("country_name")!;
        State = json.GetString("state")!;
        if (string.IsNullOrWhiteSpace(CityLatLong) || StringUtils.ParseDoubleArray(CityLatLong) is not { Length: 2 } array) return;
        CityLat = array[0];
        CityLong = array[1];
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TogglUserLocation"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="TogglUserLocation"/>.</returns>
    [return: NotNullIfNotNull(nameof(json))]
    public static TogglUserLocation? Parse(JObject? json) {
        return json == null ? null : new TogglUserLocation(json);
    }

    #endregion

}
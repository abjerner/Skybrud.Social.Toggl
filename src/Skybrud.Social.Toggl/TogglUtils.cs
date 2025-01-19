using System.Diagnostics.CodeAnalysis;
using Skybrud.Essentials.Collections;

namespace Skybrud.Social.Toggl;

/// <summary>
/// Static class with various utility and helper methods for working with the Toggl API implementation.
/// </summary>
public class TogglUtils {

    /// <summary>
    /// Converts the specified sort <paramref name="order"/> to a string, using the format as expected by the Toggl Track API.
    /// </summary>
    /// <param name="order">The sort order</param>
    /// <returns>The sort order as a string.</returns>
    [return: NotNullIfNotNull(nameof(order))]
    public static string? ToString(SortOrder? order) {
        return order is null ? null : ToString(order.Value);
    }

    /// <summary>
    /// Converts the specified sort <paramref name="order"/> to a string, using the format as expected by the Toggl Track API.
    /// </summary>
    /// <param name="order">The sort order</param>
    /// <returns>The sort order as a string.</returns>
    public static string ToString(SortOrder order) {
        return order is SortOrder.Descending ? "desc" : "asc";
    }

}
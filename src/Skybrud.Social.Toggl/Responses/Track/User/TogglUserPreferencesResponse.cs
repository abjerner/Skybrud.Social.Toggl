using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Track.User;

namespace Skybrud.Social.Toggl.Responses.Track.User {

    /// <summary>
    /// Class representing a response with a single <see cref="TogglUserPreferences"/>.
    /// </summary>
    public class TogglUserPreferencesResponse : TogglResponse<TogglUserPreferences> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response received from the Toggl API.</param>
        public TogglUserPreferencesResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglUserPreferences.Parse)!;
        }

    }

}
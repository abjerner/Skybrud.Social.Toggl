using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Entries;

namespace Skybrud.Social.Toggl.Responses.Entries {

    public class TogglEntriesResponse : TogglResponse<TogglEntry[]> {

        public TogglEntriesResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglEntry.Parse);
        }

        public static TogglEntriesResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglEntriesResponse(response);
        }

    }

}
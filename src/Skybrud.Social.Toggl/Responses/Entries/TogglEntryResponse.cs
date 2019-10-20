using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Entries;

namespace Skybrud.Social.Toggl.Responses.Entries {

    public class TogglEntryResponse : TogglResponse<TogglEntryResponseBody> {

        public TogglEntryResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglEntryResponseBody.Parse);
        }

        public static TogglEntryResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglEntryResponse(response);
        }

    }

}
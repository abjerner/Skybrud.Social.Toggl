using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Clients;

namespace Skybrud.Social.Toggl.Responses.Clients {

    public class TogglClientsResponse : TogglResponse<TogglClient[]> {

        public TogglClientsResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglClient.Parse);
        }

        public static TogglClientsResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglClientsResponse(response);
        }

    }

}
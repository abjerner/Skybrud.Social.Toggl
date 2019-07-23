using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Clients;

namespace Skybrud.Social.Toggl.Responses.Clients {

    public class TooglCreateClientResponse : TogglResponse<TogglCreateClientBody> {

        public TooglCreateClientResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglCreateClientBody.Parse);
        }

        public static TooglCreateClientResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TooglCreateClientResponse(response);
        }

    }

}
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Exceptions;

namespace Skybrud.Social.Toggl.Responses {

    public class TogglResponse : HttpResponseBase {

        public TogglResponse(IHttpResponse response) : base(response) {
            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.Created) return;
            throw new TogglHttpException(response);
        }

    }

    public class TogglResponse<T> : TogglResponse {

        public T Body { get; protected set; }

        public TogglResponse(IHttpResponse response) : base(response) { }

    }

}
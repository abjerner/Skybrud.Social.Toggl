using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Projects;

namespace Skybrud.Social.Toggl.Responses.Projects {

    public class TogglCreateProjectResponse : TogglResponse<TogglCreateProjectBody> {

        public TogglCreateProjectResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, TogglCreateProjectBody.Parse);
        }

        public static TogglCreateProjectResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglCreateProjectResponse(response);
        }

    }

}
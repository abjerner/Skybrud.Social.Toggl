using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Toggl.Models.Projects;

namespace Skybrud.Social.Toggl.Responses.Projects {

    public class TogglGetProjectsResponse : TogglResponse<TogglProject[]> {

        public TogglGetProjectsResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, TogglProject.Parse);
        }

        public static TogglGetProjectsResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new TogglGetProjectsResponse(response);
        }

    }

}
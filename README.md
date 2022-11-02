# Skybrud.Social.Toggl

Skybrud.Social service implementation for the Toggl API.

## Examples

### Initialize a new HTTP service

The `TogglHttpService` class is the entry point for communicating with the Toggl Track API:

```cshtml
@using Skybrud.Social.Toggl
@{

    // Initialize from your API token
    TogglHttpService toggl = TogglHttpService.CreateFromApiToken("Your API token");

}
```

### List all clients

```cshtml
@using Skybrud.Social.Toggl
@using Skybrud.Social.Toggl.Exceptions
@using Skybrud.Essentials.Json
@using Newtonsoft.Json.Linq
@using Skybrud.Social.Toggl.Responses.Track.Clients
@inherits UmbracoViewPage<Skybrud.Social.Toggl.TogglHttpService>
@{

    // Initialize from your API token
    TogglHttpService toggl = TogglHttpService.CreateFromApiToken("Your API token");

    try {

        // Make the request to the API
        TogglClientListResponse response = toggl.Track.Clients.GetClients();

        <table class="table list">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
                @foreach (TogglClient client in response.Body) {
                    <tr>
                        <td>@client.Id</td>
                        <td>@client.Name</td>
                    </tr>
                }
            </tbody>
        </table>

    } catch (TogglHttpException ex) {

        <pre>@ex.Response.StatusCode @ex.Response.ResponseUri</pre>
    
        <pre>@(JsonUtils.TryParseJsonToken(ex.Response.Body, out JToken token) ? token : ex.Response.Body)</pre>

    }

}
```

### List all projects

Projects are fetched via the **Workspaces** endpoint, and you must specify the ID of the workspace to retrieve projects for:

```cshtml
@using Skybrud.Social.Toggl
@using Skybrud.Social.Toggl.Exceptions
@using Skybrud.Essentials.Json
@using Newtonsoft.Json.Linq
@using Skybrud.Social.Toggl.Models.Track.Projects
@using Skybrud.Social.Toggl.Options.Track.Projects
@using Skybrud.Social.Toggl.Responses.Track.Projects
@inherits UmbracoViewPage<Skybrud.Social.Toggl.TogglHttpService>
@{

    // Initialize from your API token
    TogglHttpService toggl = TogglHttpService.CreateFromApiToken("Your API token");

    try {

        // Make the request to the API
        TogglProjectListResponse response = toggl.Track.Workspaces.GetProjects(123456, TogglProjectActiveState.Both);

        <table class="table list">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>ClientID</th>
                    <th>HEX</th>
                </tr>
            </thead>
            <tbody>
                @foreach (TogglProject project in response.Body) {
                    <tr>
                        <td>@project.Id</td>
                        <td>@project.Name</td>
                        <td>@project.ClientId</td>
                        <td>@project.HexColor</td>
                    </tr>
                }
            </tbody>
        </table>

    } catch (TogglHttpException ex) {

        <pre>@ex.Response.StatusCode @ex.Response.ResponseUri</pre>
    
        <pre>@(JsonUtils.TryParseJsonToken(ex.Response.Body, out JToken token) ? token : ex.Response.Body)</pre>

    }

}
```

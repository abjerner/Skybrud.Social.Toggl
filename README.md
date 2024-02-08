# Skybrud.Social.Toggl

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/abjerner/Skybrud.Social.Toggl/blob/v1/main/LICENSE.md)
[![NuGet](https://img.shields.io/nuget/vpre/Skybrud.Social.Toggl.svg)](https://www.nuget.org/packages/Skybrud.Social.Toggl)
[![NuGet](https://img.shields.io/nuget/dt/Skybrud.Social.Toggl.svg)](https://www.nuget.org/packages/Skybrud.Social.Toggl)

.NET API wrapper and implementation of the [**Toggl Track API**](https://developers.track.toggl.com/docs/).

<table>
  <tr>
    <td><strong>License:</strong></td>
    <td><a href="https://github.com/abjerner/Skybrud.Social.Toggl/blob/v1/main/LICENSE.md"><strong>MIT License</strong></a></td>
  </tr>
  <tr>
    <td><strong>Target Framework:</strong></td>
    <td>
      .NET 4.5, .NET 4.6, .NET 4.7 and .NET Standard 2.0
    </td>
  </tr>
</table>






<br /><br />

## Installation

The package is only available via [**NuGet**](https://www.nuget.org/packages/Skybrud.Social.Toggl/1.0.0-beta005). To install the package, you can either use the .NET CLI:

```
dotnet add package Skybrud.Social.Toggl --version 1.0.0-beta005
```

or the NuGet Package Manager:

```
Install-Package Skybrud.Social.Toggl -Version 1.0.0-beta005
```











<br /><br />

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

    // Declare your workspace ID
    int workspaceId = 1234;

    // Initialize from your API token
    TogglHttpService toggl = TogglHttpService.CreateFromApiToken("Your API token");

    try {

        // Make the request to the API
        TogglClientListResponse response = toggl.Track.Clients.GetClients(workspaceId);

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

Projects are fetched via the **Projects** endpoint, and you must specify the ID of the workspace to retrieve projects for:

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

    // Declare your workspace ID
    int workspaceId = 1234;

    // Initialize from your API token
    TogglHttpService toggl = TogglHttpService.CreateFromApiToken("Your API token");

    try {

        // Make the request to the API
        TogglProjectListResponse response = toggl.Track.Workspaces.GetProjects(workspaceId);

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

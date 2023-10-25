using Google.Api.Gax;

namespace Logic.Services;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.ResourceManager.V3;
using Google.Cloud.ServiceUsage.V1;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GetServiceData : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string accessToken)
    {
        GoogleCredential credential = GoogleCredential.FromAccessToken(accessToken);
        ProjectsClient = new ProjectsClientBuilder
        { Credential = credential.}Build();
        
        PagedEnumerable<SearchProjectsResponse, Projects>
    }
}
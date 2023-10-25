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
        ProjectsClient client = new ProjectsClientBuilder { Credential = credential}.Build();

        PagedEnumerable<SearchProjectsResponse, Project> projects = client.SearchProjects("");
        List<Service> aiServices = new List<Service>();
        
        foreach (Project project in projects)
        {
            ServiceUsageClient? serviceUsageClient = new ServiceUsageClientBuilder
            {
                Credential = credential
            }.Build();
            PagedEnumerable<ListServicesResponse, Service> services =
                serviceUsageClient.ListServices(new ListServicesRequest
                    { Parent = project.Name, Filter = "state:ENABLED" });

            foreach (Service service in services)
            {
                string serviceTitle = service.Config.Title;
                if (serviceTitle.StartsWith("AI ") || serviceTitle.Contains(" AI ") || serviceTitle.EndsWith(" AI"))
                {
                    aiServices.Add(service);
                }
            }
        }

        return Ok(aiServices);
    }
}
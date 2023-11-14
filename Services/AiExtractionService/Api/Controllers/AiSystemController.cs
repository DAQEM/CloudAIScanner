using System.Net.Http.Headers;
using Amazon.Runtime;
using Google.Api.Gax;

namespace Logic.Services;

using Google.Apis.Auth.OAuth2;
using Google.Cloud.ResourceManager.V3;
using Google.Cloud.ServiceUsage.V1;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AiSystemController : ControllerBase
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

    [HttpGet]
    public async Task<IActionResult> GetOpenAi(string accessToken)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await client.GetAsync("https://api.openai.com/v1/models");
                response.EnsureSuccessStatusCode();
                //var credential = open
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request exception: {e.Message}");
            }
        }

        return Ok();
    }
    
    
   // [HttpGet]
   // public IActionResult Get(string awsAccessKeyId, string awsSecretAccessKey, string awsRegion)
   // {
   //     var credentials = new BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey);
   //     var config = new AmazonProjectConfig
   //     {
   //         RegionEndpoint = RegionEndpoint.GetBySystemName(awsRegion)
   //     };
   //
   //     using (var client = new AmazonProjectClient(credentials, config))
   //     {
   //         var request = new SearchProjectsRequest
   //         {
   //             // Fill in the appropriate search parameters here
   //         };
   //
   //         var response = client.SearchProjects(request);
   //
   //         List<Service> aiServices = new List<Service>();
   //
   //         foreach (var project in response.Projects)
   //         {
   //             using (var serviceUsageClient = new AmazonServiceUsageClient(credentials, config))
   //             {
   //                 var serviceRequest = new ListServicesRequest
   //                 {
   //                     Parent = project.Name,
   //                     Filter = "state:ENABLED"
   //                 };
   //
   //                 var servicesResponse = serviceUsageClient.ListServices(serviceRequest);
   //
   //                 foreach (var service in servicesResponse.Services)
   //                 {
   //                     string serviceTitle = service.Config.Title;
   //                     if (serviceTitle.StartsWith("AI ") || serviceTitle.Contains(" AI ") || serviceTitle.EndsWith(" AI"))
   //                     {
   //                         aiServices.Add(service);
   //                     }
   //                 }
   //             }
   //         }
   //
   //         return Ok(aiServices);
   //     }
   // }
}

using Google.Api.Gax;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.ResourceManager.V3;
using Google.Cloud.ServiceUsage.V1;
using Logic.Interfaces;
using System.Net.Http.Headers;

namespace Extraction.Repository
{
    public class ServiceRepository : IServiceRepository
    {

        public List<Service> GetGoogleCloud(string accessToken)
        {
            GoogleCredential credential = GoogleCredential.FromAccessToken(accessToken);
            ProjectsClient projectClient = new ProjectsClientBuilder
            { Credential = credential }.Build();

            PagedEnumerable<SearchProjectsResponse, Project> projects = projectClient.SearchProjects("");
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

            return aiServices;
        }

        public async Task<string> GetOpenAI(string accessToken)
        {
            string responseBody = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    HttpResponseMessage response = await client.GetAsync("https://api.openai.com/v1/models");
                    response.EnsureSuccessStatusCode();
                    //var credential = open
                    responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }

            return responseBody;
        }
    }
}

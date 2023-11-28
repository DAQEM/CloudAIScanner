using Google.Api.Gax;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.ResourceManager.V3;
using Google.Cloud.ServiceUsage.V1;
using Logic.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using logic.Dtos;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        public async Task<List<OpenAiModelDto>> GetOpenAI(string apiKey)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                    HttpResponseMessage response = await client.GetAsync("https://api.openai.com/v1/models");
                    response.EnsureSuccessStatusCode();

                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string responseBody = await response.Content.ReadAsStringAsync();
                    OpenAiResponseDto? openAiResponse = JsonSerializer.Deserialize<OpenAiResponseDto>(responseBody, options);

                    return openAiResponse?.Data ?? new List<OpenAiModelDto>();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }

            return new List<OpenAiModelDto>();
        }
    }
    
    public class OpenAiResponseDto
    {
        public string Object { get; set; }
        public List<OpenAiModelDto> Data { get; set; }
    }
}

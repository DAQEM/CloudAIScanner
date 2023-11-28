using System.Net.Http.Headers;
using AiExtractionService.Dtos;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using logic.Entities;

namespace AiExtractionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleCloudController : ControllerBase
    {
        private IAiService _aiService;

        public GoogleCloudController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string accessToken)
        {
            List<AiSystem> services = new();

            services.AddRange(_aiService.GetGoogleCloud(accessToken));
            
            HttpClient client = new();
            //get environment dev or prod
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            client.BaseAddress = environment == "Development" ? new Uri("http://localhost:5052/api/AISystem") : new Uri("http://ai-register:8080/api/AISystem");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<HttpResponseMessage> responses = new();
            foreach (AiSystem service in services)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("AISystem", service);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                responses.Add(response);
            }
            return responses.Any(r => r.IsSuccessStatusCode) ? Ok() : BadRequest();
        }
    }
}

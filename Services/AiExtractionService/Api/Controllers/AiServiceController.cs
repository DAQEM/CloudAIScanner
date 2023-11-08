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
    public class AiServiceController : ControllerBase
    {
        private IAiService _aiService;

        public AiServiceController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string accessToken)
        {
            List<AiSystem> services = new();

            services.AddRange(_aiService.Get(accessToken));
            
            HttpClient client = new();
            //get environment dev or prod
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            client.BaseAddress = environment == "Development" ? new Uri("http://localhost:5052/api/AISystem") : new Uri("http://ai-register-service/api/AISystem");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string result = "";
            foreach (AiSystem service in services)
            {
                HttpResponseMessage response = client.PostAsJsonAsync("AISystem", service).Result;
                result = await response.Content.ReadAsStringAsync();
            }
            return new JsonResult(result);
        }
    }
}

using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using logic.Dtos;
using logic.Entities;
using logic.Models;

namespace AiExtractionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        private IAiService _aiService;

        public OpenAiController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string apiKey)
        {
            var openAiModelDtos = await _aiService.GetOpenAI(apiKey);

            return Ok(openAiModelDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<OpenAiModelDto> models)
        {
            //zet models om in AiSystems en stuur naar AiRegister
            List<AiSystem> aiSystems = models.Select(dto => new AiSystem
            {
                Name = dto.Id,
                UnambiguousReference = dto.Id,
                Description =
                    $"{dto.Id} owned by {dto.OwnedBy} and created on: {new DateTime(dto.Created).ToLongDateString()}",
                Provider = new AiSystemProvider
                {
                    Guid = Guid.Parse("15085208-a80f-42c8-8a75-c39c87384941")
                },
                Status = AiStatus.InService,
                ApprovalStatus = ApprovalStatus.Pending,
                certificate = new AiSystemCertificate
                {
                    Type = "Example Certificate",
                    Number = 123456789,
                    ExpiryDate = DateTime.Now.AddYears(3),
                    ScanCertificate = new AiSystemScanCertificate
                    {
                        Filename = "example_certificate.pdf",
                        Filepath = "https://example.com/example_certificate.pdf"
                    },
                    IdNotifiedBody = 1,
                    NameNotifiedBody = "Example Notified Body"
                },
                Files = new List<AISystemFile>(),
                DateAdded = DateOnly.FromDateTime(DateTime.Now),
                MemberState = MemberStates.Latvia | MemberStates.Lithuania | MemberStates.Luxembourg |
                              MemberStates.Malta | MemberStates.Netherlands | MemberStates.Poland |
                              MemberStates.Portugal | MemberStates.Romania | MemberStates.Slovakia |
                              MemberStates.Slovenia | MemberStates.Spain | MemberStates.Sweden,
                URL = "https://example.com",
                TechnicalDocumentationLink = "https://example.com/technical_documentation"
            }).ToList();
            
            HttpClient client = new();
            //get environment dev or prod
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            client.BaseAddress = environment == "Development" ? new Uri("http://localhost:5052/api/AISystem") : new Uri("http://ai-register:8080/api/AISystem");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<HttpResponseMessage> responses = new();
            foreach (AiSystem service in aiSystems)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("AISystem", service);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                responses.Add(response);
            }
            return responses.Any(r => r.IsSuccessStatusCode) ? Ok() : BadRequest();
        }
    }
}
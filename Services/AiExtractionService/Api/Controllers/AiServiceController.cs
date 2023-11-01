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
        public IActionResult Get(string accessToken)
        {
            List<AiSystemModel> services = new();

            services.AddRange(_aiService.Get(accessToken));

            return Ok(services);
        }
    }
}

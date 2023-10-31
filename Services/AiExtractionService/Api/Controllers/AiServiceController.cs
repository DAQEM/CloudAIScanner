using AiExtractionService.Dtos;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
            List<AiServiceDto> services = new List<AiServiceDto>();

            _aiService.Get(accessToken);

            return Ok(services);
        }
    }
}

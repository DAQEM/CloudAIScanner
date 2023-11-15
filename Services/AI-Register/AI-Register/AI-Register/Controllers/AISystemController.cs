using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using AIRegister.DTOs;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HttpExceptionHandling]
    public class AISystemController : ControllerBase
    {
        private AISystemService _aiSystemService;


        public AISystemController(IAISystemRepository aiSystem)
        {
            _aiSystemService = new AISystemService(aiSystem);
        }
        // GET: api/<AISystemController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<AISystem> aisystems = await _aiSystemService.GetAiSystems();
            List<GetAISystemDTO> getAISystemDTOs = new List<GetAISystemDTO>();
            foreach (AISystem system in aisystems)
            { 
                GetAISystemDTO getAISystemDTO = new GetAISystemDTO(
                    system.Guid, 
                    system.Name, 
                    system.provider.Name, 
                    system.DateAdded, 
                    system.ApprovalStatus, 
                    system.Description,
                    system.UnambiguousReference);
                getAISystemDTOs.Add(getAISystemDTO);
            }
            return  Ok(getAISystemDTOs);
        }

        // POST: api/AISystem
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AISystem aiSystem)
        {
            
                AISystem returnAISystem = await _aiSystemService.AddAiSystem(aiSystem);
                return Created(new Uri(Request.GetDisplayUrl()), returnAISystem);
        }

        // GET api/<AISystemController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
          
            AISystem aisystem = await _aiSystemService.getAISystemById(id);
            ProviderDTO providerDTO = new ProviderDTO(aisystem.provider);
            CertificateDTO certificateDTO = new CertificateDTO(aisystem.certificate);
            AIDetailDTO aiDetailDTO = new AIDetailDTO(
                aisystem.Guid, 
                aisystem.Name, 
                aisystem.Status, 
                aisystem.URL, 
                aisystem.TechnicalDocumentationLink, 
                aisystem.ApprovalStatus, 
                aisystem.DateAdded, 
                providerDTO, 
                certificateDTO, 
                aisystem.Files.ToList(), 
                aisystem.Description, 
                aisystem.MemberState,
                aisystem.UnambiguousReference);

            return Ok(aiDetailDTO);
        }
        // PUT: api/AISystem/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AIUpdateDTO aiUpdateDto)
        {
            AISystem aiSystem = new AISystem()
            {
                Name = aiUpdateDto.Name,
                Status = aiUpdateDto.Status,
                TechnicalDocumentationLink = aiUpdateDto.TechnicalDocumentationLink,
                URL = aiUpdateDto.Url,
                Guid = aiUpdateDto.Guid,
                Description = aiUpdateDto.Description,
                ApprovalStatus = aiUpdateDto.ApprovalStatus,
                MemberState = aiUpdateDto.MemberState
            };
            AISystem returnAiSystem = await _aiSystemService.UpdateAISystem(aiSystem);
            return Created(new Uri(Request.GetDisplayUrl()), returnAiSystem);
            
         
        }

        // GET api/<AISystemController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _aiSystemService.DeleteAiSystem(id);
            return Ok();
        }

    }
}

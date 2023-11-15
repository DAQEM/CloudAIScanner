using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using AIRegister.DTOs;
using Microsoft.AspNetCore.Http.Extensions;

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AISystemController : ControllerBase
    {
        private AISystemService _aiSystemService;

        public AISystemController(IAISystemRepository aiSystem)
        {
            _aiSystemService = new AISystemService(aiSystem);
        }
        // GET: api/<AISystemController>
        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 20)
        {
            pageSize = Math.Clamp(pageSize, 1, 500);
            
            try
            {
                Pagination<List<AISystem>> aisystems = _aiSystemService.GetAiSystems(page, pageSize);
                List<GetAISystemDTO> getAISystemDTOs = new List<GetAISystemDTO>();
                foreach (AISystem system in aisystems.Data)
                {
                    GetAISystemDTO getAISystemDTO = new GetAISystemDTO(system.Guid, system.Name, system.provider.Name,
                        system.DateAdded, system.ApprovalStatus, system.Description, system.UnambiguousReference);
                    getAISystemDTOs.Add(getAISystemDTO);
                }

                return Ok(new PaginationDTO<List<GetAISystemDTO>>
                {
                    Data = getAISystemDTOs,
                    Page = aisystems.Page,
                    PageSize = aisystems.PageSize,
                    TotalPages = aisystems.TotalPages
                });

            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // POST: api/AISystem
        [HttpPost]
        public IActionResult Post([FromBody]AISystem aiSystem)
        {
            try
            {
                AISystem returnAISystem = _aiSystemService.AddAiSystem(aiSystem);
                return Created(new Uri(Request.GetDisplayUrl()), returnAISystem);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // GET api/<AISystemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                AISystem aisystem = _aiSystemService.getAISystemById(id);
                ProviderDTO providerDTO = new ProviderDTO(aisystem.provider);
                CertificateDTO certificateDTO = new CertificateDTO(aisystem.certificate);
                AIDetailDTO aiDetailDTO = new AIDetailDTO(aisystem.Guid, aisystem.Name, aisystem.Status, aisystem.URL, aisystem.TechnicalDocumentationLink, aisystem.ApprovalStatus, aisystem.DateAdded, providerDTO, certificateDTO, aisystem.Files.ToList(), aisystem.Description, aisystem.MemberState, aisystem.UnambiguousReference);

                return Ok(aiDetailDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
 
        }
        // PUT: api/AISystem/
        [HttpPut]
        public IActionResult Put([FromBody] AIUpdateDTO aiUpdateDto)
        {
            try
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
                AISystem returnAiSystem = _aiSystemService.UpdateAISystem(aiSystem);
                return Created(new Uri(Request.GetDisplayUrl()), returnAiSystem);
            }
            catch(Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // GET api/<AISystemController>/5
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _aiSystemService.DeleteAiSystem(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AIRegister.DTOs;
using Microsoft.AspNetCore.Http.Extensions;

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AISystemController : ControllerBase
    {
        
        private readonly IAISystemRepository _aiSystem;

        public AISystemController(IAISystemRepository aiSystem)
        {
            _aiSystem = aiSystem;
        }
        // GET: api/<AISystemController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                AISystemService aisystemService = new AISystemService(_aiSystem);
                List<AISystem> aisystems = aisystemService.GetAiSystems();
                List<GetAISystemDTO> getAISystemDTOs = new List<GetAISystemDTO>();
                foreach (AISystem system in aisystems)
                {
                    GetAISystemDTO getAISystemDTO = new GetAISystemDTO(system.Guid, system.Name, system.provider.Name,
                        system.DateAdded, system.ApprovalStatus, system.Description);
                    getAISystemDTOs.Add(getAISystemDTO);
                }

                return Ok(getAISystemDTOs);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/AISystem
        [HttpPost]
        public IActionResult Post([FromServices] IAISystemRepository aiSystemRepository, AISystem aiSystem)
        {
            try
            {
                AISystemService aiSystemService = new AISystemService(aiSystemRepository);
                
                AISystem returnAISystem = aiSystemService.AddAiSystem(aiSystem);
                return Created(new Uri(Request.GetDisplayUrl()), returnAISystem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<AISystemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                AISystemService aisystemService = new AISystemService(_aiSystem);
                AISystem aisystem = aisystemService.getAISystemById(id);
                ProviderDTO providerDTO = new ProviderDTO(aisystem.provider);
                CertificateDTO certificateDTO = new CertificateDTO(aisystem.certificate);
                AIDetailDTO aiDetailDTO = new AIDetailDTO(aisystem.Guid, aisystem.Name, aisystem.Status, aisystem.URL, aisystem.TechnicalDocumentationLink, aisystem.ApprovalStatus, aisystem.DateAdded, providerDTO, certificateDTO, aisystem.Files.ToList(), aisystem.Description, aisystem.MemberState);

                return Ok(aiDetailDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
 
        }
        // PUT: api/AISystem/
        [HttpPut]
        public IActionResult Put([FromServices] IAISystemRepository aiSystemRepository, AIUpdateDTO aiUpdateDto)
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
                    ApprovalStatus = aiUpdateDto.ApprovalStatus
                };
              AISystemService aiSystemService = new AISystemService(aiSystemRepository);
                aiSystemService.UpdateAISystem(aiSystem);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

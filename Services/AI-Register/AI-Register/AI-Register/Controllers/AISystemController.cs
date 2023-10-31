using AIRegister.DTOs;
using BusinessLogic.Classes;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using DAL.Migrations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
                AIsystemService aisystemService = new AIsystemService(_aiSystem);
                List<AISystem> aisystems = aisystemService.GetAiSystems();
                List<GetAISystemDTO> getAISystemDTOs = new List<GetAISystemDTO>();
                foreach (AISystem sytem in aisystems)
                {
                    GetAISystemDTO getAISystemDTO = new GetAISystemDTO(sytem.Guid, sytem.Name, sytem.provider.Name, sytem.DateAdded, sytem.ApprovalStatus);
                    getAISystemDTOs.Add(getAISystemDTO);
                }

                return Ok(getAISystemDTOs);
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
                AIsystemService aisystemService = new AIsystemService(_aiSystem);
                AISystem aisystem = aisystemService.setAISystemById(id);
                ProviderDTO providerDTO = new ProviderDTO(aisystem.provider);
                CertificateDTO certificateDTO = new CertificateDTO(aisystem.certificate);
                AIDetailDTO aiDetailDTO = new AIDetailDTO(aisystem.Guid, aisystem.Name, aisystem.Status, aisystem.URL, aisystem.TechnicalDocumentationLink, aisystem.Status, aisystem.DateAdded, providerDTO, certificateDTO, aisystem.Files.ToList());

                return Ok(aiDetailDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
 
        }

    }
}

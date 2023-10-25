using AIRegister.DTOs;
using BusinessLogic.Classes;
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
        
        private readonly IAISystem _aiSystem;

        public AISystemController(IAISystem aiSystem)
        {
            _aiSystem = aiSystem;
        }
        // GET: api/<AISystemController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                AISystemCollection aiSystemCollection = new AISystemCollection(_aiSystem);
                GetAllSystemDTO getAllSystemDTO = new GetAllSystemDTO();
                aiSystemCollection.SetAiSystemsWithProviders();
                foreach (AISystem sytem in aiSystemCollection.AISystems)
                {
                    GetAISystemDTO getAISystemDTO = new GetAISystemDTO(sytem.Guid, sytem.Name, sytem.provider.Name, sytem.DateAdded, sytem.ApprovalStatus);
                    getAllSystemDTO.AISystems.Add(getAISystemDTO);
                }

                return Ok(getAllSystemDTO);
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
                AISystem aisystem = new AISystem(_aiSystem);
                aisystem.setAISystemById(id);

                ProviderDTO providerDTO = new ProviderDTO();
                providerDTO.toProviderDTO(aisystem.provider);

                CertificateDTO certificateDTO = new CertificateDTO();
                certificateDTO.toCertificateDTO(aisystem.certificate);

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

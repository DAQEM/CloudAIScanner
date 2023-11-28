using AIRegister.DTOs;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HttpExceptionHandling]
    public class RepresentativeController : ControllerBase
    {
        private RepresentativeService _representativeService;
        
        public RepresentativeController(IRepresentativeRepository representative)
        {
            _representativeService = new RepresentativeService(representative);
        }
        // GET: api/Representative
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<AuthorisedRepresentative> authorisedRepresentatives = await _representativeService.GetAuthorisedRepresentatives();
                List<AuthorisedRepresentativeDTO> RepresentativeDTOs = new List<AuthorisedRepresentativeDTO>();
                foreach (AuthorisedRepresentative representative in authorisedRepresentatives)
                {
                    AuthorisedRepresentativeDTO RepresentativeDTO = new AuthorisedRepresentativeDTO(
                        representative.guid,
                        representative.Name, 
                        representative.Email, 
                        representative.PhoneNumber);
                    RepresentativeDTOs.Add(RepresentativeDTO);
                }
                return Ok(RepresentativeDTOs);
        }

        // GET: api/Representative/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            AuthorisedRepresentative authorisedRepresentative = await _representativeService.GetAuthorisedRepresentativeById(id);
            AuthorisedRepresentativeProviderDTO RepresentativeDTO = new AuthorisedRepresentativeProviderDTO(
                authorisedRepresentative.guid, 
                authorisedRepresentative.Name,
                authorisedRepresentative.Email,
                authorisedRepresentative.PhoneNumber, 
                new ProviderDTO(authorisedRepresentative.Provider));

            return Ok(RepresentativeDTO);
        }

        // POST: api/Representative
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorisedRepresentative authorisedRepresentative)
        {
            AuthorisedRepresentative returnAuthorisedRepresentative = await _representativeService.CreateAuthorisedRepresentative(authorisedRepresentative);
            return Created(new Uri(Request.GetDisplayUrl()), returnAuthorisedRepresentative);
        }

        // PUT: api/Representative/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateAuthorisedRepresentativeDTO authorisedRepresentativeDto)
        {
            AuthorisedRepresentative authorisedRepresentative = new AuthorisedRepresentative()
            {   
                guid = id,
                Name = authorisedRepresentativeDto.Name,
                Email = authorisedRepresentativeDto.Email,
                PhoneNumber = authorisedRepresentativeDto.PhoneNumber
            };
            AuthorisedRepresentative returnAuthorisedRepresentative = await _representativeService.UpdateAuthorisedRepresentative(authorisedRepresentative);
            return Created(new Uri(Request.GetDisplayUrl()), returnAuthorisedRepresentative);
        }

        // DELETE: api/Representative/5
        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(Guid id)
        {
            await _representativeService.DeleteAuthorisedRepresentative(id);
            return Ok();
        }
    }
}

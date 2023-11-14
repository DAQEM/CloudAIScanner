using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIRegister.DTOs;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeController : ControllerBase
    {
        private RepresentativeService _representativeService;
        
        public RepresentativeController(IRepresentativeRepository representative)
        {
            _representativeService = new RepresentativeService(representative);
        }
        // GET: api/Representative
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<AuthorisedRepresentative> authorisedRepresentatives =
                    _representativeService.GetAuthorisedRepresentatives();
                List<AuthorisedRepresentativeDTO> RepresentativeDTOs = new List<AuthorisedRepresentativeDTO>();
                foreach (AuthorisedRepresentative representative in authorisedRepresentatives)
                {
                    AuthorisedRepresentativeDTO RepresentativeDTO = new AuthorisedRepresentativeDTO(representative.guid,
                        representative.Name, representative.Email, representative.PhoneNumber);
                    RepresentativeDTOs.Add(RepresentativeDTO);
                }
                return Ok(RepresentativeDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // GET: api/Representative/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                AuthorisedRepresentative authorisedRepresentative = _representativeService.GetAuthorisedRepresentativeById(id);
                AuthorisedRepresentativeProviderDTO RepresentativeDTO = new AuthorisedRepresentativeProviderDTO(authorisedRepresentative.guid,
                    authorisedRepresentative.Name, authorisedRepresentative.Email, authorisedRepresentative.PhoneNumber, new ProviderDTO(authorisedRepresentative.Provider));
                return Ok(RepresentativeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // POST: api/Representative
        [HttpPost]
        public IActionResult Post([FromBody] AuthorisedRepresentative authorisedRepresentative)
        {
            try
            {
               AuthorisedRepresentative returnAuthorisedRepresentative = _representativeService.CreateAuthorisedRepresentative(authorisedRepresentative);
               return Created(new Uri(Request.GetDisplayUrl()), returnAuthorisedRepresentative);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // PUT: api/Representative/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateAuthorisedRepresentativeDTO authorisedRepresentativeDto)
        {
            try
            {
                AuthorisedRepresentative authorisedRepresentative = new AuthorisedRepresentative()
                {   
                    guid = id,
                    Name = authorisedRepresentativeDto.Name,
                    Email = authorisedRepresentativeDto.Email,
                    PhoneNumber = authorisedRepresentativeDto.PhoneNumber
                };
                AuthorisedRepresentative returnAuthorisedRepresentative = _representativeService.UpdateAuthorisedRepresentative(authorisedRepresentative);
                return Created(new Uri(Request.GetDisplayUrl()), returnAuthorisedRepresentative);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // DELETE: api/Representative/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                 _representativeService.DeleteAuthorisedRepresentative(id);
                 return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}

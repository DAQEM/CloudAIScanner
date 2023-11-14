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
    public class ProviderController : ControllerBase
    {
        private readonly ProviderService _providerService;

        public ProviderController(IProviderRepository provider)
        {
            _providerService = new ProviderService(provider);

        }

        // POST: api/Provider
        [HttpPost]
        public IActionResult Post([FromBody] Provider provider)
        {
            try
            {
                Provider returnProvider = _providerService.CreateProvider(provider);
                return Created(new Uri(Request.GetDisplayUrl()), returnProvider);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // PUT: api/Provider/5
        
        [HttpPut]
        public IActionResult Put([FromBody] ProviderUpdateDTO providerUpdateDto)
        {
            try
            {
                Provider provider = new Provider()
                {
                    Name = providerUpdateDto.Name,
                    Address = providerUpdateDto.Address,
                    guid = providerUpdateDto.Guid,
                    PhoneNumber = providerUpdateDto.PhoneNumber,
                    Email = providerUpdateDto.Email
                };
                Provider returnProvider = _providerService.UpdateProvider(provider);
                return Created(new Uri(Request.GetDisplayUrl()), returnProvider);
            }
            catch(Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        // DELETE: api/Provider/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id )
        {
            try
            {
                _providerService.DeleteProvider(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ProviderDTO> providerDtos = new List<ProviderDTO>();
                List<Provider> providers = _providerService.GetProviders();
                foreach (Provider provider in providers)
                {
                    providerDtos.Add(new ProviderDTO(provider));
                }
                return Ok(providers);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
               Provider provider = _providerService.GetProviderById(id);
               ProviderAISystemDTO providerAiSystemDto = new ProviderAISystemDTO(provider);
               foreach (AISystem system in provider.AISystems)
               {
                   GetAISystemDTO getAISystemDTO = new GetAISystemDTO(system.Guid, system.Name, provider.Name, system.DateAdded, system.ApprovalStatus, system.Description);
                   providerAiSystemDto.AiSystemDtos.Add(getAISystemDTO);
               }
               return Ok(providerAiSystemDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

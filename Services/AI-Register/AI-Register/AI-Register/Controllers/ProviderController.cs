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
    public class ProviderController : ControllerBase
    {
        private readonly ProviderService _providerService;

        public ProviderController(IProviderRepository provider)
        {
            _providerService = new ProviderService(provider);

        }

        // POST: api/Provider
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Provider provider)
        {
            Provider returnProvider = await _providerService.CreateProvider(provider);
            return Created(new Uri(Request.GetDisplayUrl()), returnProvider);
        }

        // PUT: api/Provider/5
        
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProviderUpdateDTO providerUpdateDto)
        {

            Provider provider = new Provider()
            {
                Name = providerUpdateDto.Name,
                Address = providerUpdateDto.Address,
                guid = providerUpdateDto.Guid,
                PhoneNumber = providerUpdateDto.PhoneNumber,
                Email = providerUpdateDto.Email
            };
            Provider returnProvider = await _providerService.UpdateProvider(provider);
            return Created(new Uri(Request.GetDisplayUrl()), returnProvider);


        }

        // DELETE: api/Provider/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id )
        { 
            await _providerService.DeleteProvider(id);
            return Ok();
         
      
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ProviderDTO> providerDtos = new List<ProviderDTO>();
                List<Provider> providers = await _providerService.GetProviders();
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
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
               Provider provider = await _providerService.GetProviderById(id);
               ProviderAISystemDTO providerAiSystemDto = new ProviderAISystemDTO(provider);
               foreach (AISystem system in provider.AISystems)
               {
                   GetAISystemDTO getAISystemDTO = new GetAISystemDTO(system.Guid, system.Name, provider.Name, system.DateAdded, system.ApprovalStatus, system.Description, system.UnambiguousReference);
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

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
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
    }
}

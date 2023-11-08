using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
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
    public class ProviderController : ControllerBase
    {
        private readonly IProviderRepository _provider;

        public ProviderController(IProviderRepository provider)
        {
            _provider = provider;
        }

        // POST: api/Provider
        [HttpPost]
        public IActionResult Post([FromServices] IProviderRepository providerRepository, Provider provider)
        {
            try
            {
                ProviderService providerService = new ProviderService(providerRepository);
                Provider returnProvider = providerService.CreateProvider(provider);
                return Created(new Uri(Request.GetDisplayUrl()), returnProvider);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // PUT: api/Provider/5
        
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
                    ApprovalStatus = aiUpdateDto.ApprovalStatus,
                    MemberState = aiUpdateDto.MemberState
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

        // DELETE: api/Provider/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id )
        {
            try
            {
                ProviderService providerservice = new ProviderService(_provider); 
                providerservice.DeleteProvider(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

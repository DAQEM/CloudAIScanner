using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Provider/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        // POST: api/Provider
        [HttpPost]
        public void Post([FromServices] IProviderRepository providerRepository, Provider provider)
        {
            ProviderService providerService = new ProviderService(providerRepository);
            providerService.CreateProvider(provider);
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

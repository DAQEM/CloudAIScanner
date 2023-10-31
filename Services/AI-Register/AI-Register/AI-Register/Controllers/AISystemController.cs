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
    public class AISystemController : ControllerBase
    {
        // GET: api/AISystem
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AISystem/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AISystem
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/AISystem/5
        [HttpPut("{id}")]
        public IActionResult Put([FromServices] IAISystemRepository aiSystemRepository, AISystem aiSystem)
        {
            try
            {
                AISystemService aiSystemService = new AISystemService(aiSystemRepository);
                aiSystemService.UpdateAISystem(aiSystem);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/AISystem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using AIRegister.DTOs;
using BusinessLogic.Helpers;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [HttpExceptionHandling]
    public class AISystemStatusController : ControllerBase
    {
        // GET: api/<AISystemStatus>
        [HttpGet]
        public IActionResult Get()
        {
            List<EnumDTO> aiSystemStatusEnumCollection = new List<EnumDTO>();
            foreach (string status in EnumHelper.EnumToList<AISystemStatus>())
            {
                EnumDTO aiSystemStatusEnum = new EnumDTO();
                aiSystemStatusEnum.Name = status;
                aiSystemStatusEnum.id = EnumHelper.EnumParse<AISystemStatus>(status);
                aiSystemStatusEnumCollection.Add(aiSystemStatusEnum);

            }

            return Ok(aiSystemStatusEnumCollection);
        }

        // GET api/<AISystemStatus>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(EnumHelper.EnumToString<AISystemStatus>(id));
        }

    }
}

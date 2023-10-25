using AIRegister.DTOs;
using BusinessLogic.Classes;
using BusinessLogic.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AISystemStatusController : ControllerBase
    {
        // GET: api/<AISystemStatus>
        [HttpGet]
        public IEnumerable<AISystemStatusEnumDTO> Get()
        {
            AISystemStatusEnumCollectionDTO aiSystemStatusEnumCollection = new AISystemStatusEnumCollectionDTO();
            foreach (string status in EnumHelper.EnumToList<AIRegisterEnum.AISystemStatus>())
            {
                AISystemStatusEnumDTO aiSystemStatusEnum = new AISystemStatusEnumDTO();
                aiSystemStatusEnum.Name = status;
                aiSystemStatusEnum.id = EnumHelper.EnumParse<AIRegisterEnum.AISystemStatus>(status);
                aiSystemStatusEnumCollection.SystemStatuses.Add(aiSystemStatusEnum);

            }

            return aiSystemStatusEnumCollection.SystemStatuses;
        }

        // GET api/<AISystemStatus>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return EnumHelper.EnumToString<AIRegisterEnum.AISystemStatus>(id);
        }

    }
}

using AIRegister.DTOs;
using BusinessLogic.Classes;
using BusinessLogic.Enums;
using BusinessLogic.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberStateController : ControllerBase
    {
        // GET: api/<MemberStateController>
        [HttpGet]
        public IActionResult Get()
        {
            List<EnumDTO> aiSystemStatusEnumCollection = new List<EnumDTO>();
            foreach (string status in EnumHelper.EnumToList<MemberStates>())
            {
                EnumDTO aiSystemStatusEnum = new EnumDTO();
                aiSystemStatusEnum.Name = status;
                aiSystemStatusEnum.id = EnumHelper.EnumParse<MemberStates>(status);
                aiSystemStatusEnumCollection.Add(aiSystemStatusEnum);

            }

            return Ok(aiSystemStatusEnumCollection);
        }

        // GET api/<MemberStateController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(EnumHelper.EnumToString<MemberStates>(id));
        }

    }
}

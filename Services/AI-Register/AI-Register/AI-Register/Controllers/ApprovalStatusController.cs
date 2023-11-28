using AIRegister.DTOs;
using BusinessLogic.Enums;
using BusinessLogic.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApprovalStatusController : ControllerBase
    {
        // GET: api/<ApprovalStatusController>
        [HttpGet]
        public IActionResult  Get()
        {
           
            List<EnumDTO> approvalStatusCollection = new List<EnumDTO>();
            foreach (string approval in EnumHelper.EnumToList<ApprovalStatus>())
            {
                EnumDTO approvalStatusDTO = new EnumDTO();
                approvalStatusDTO.Name = approval;
                approvalStatusDTO.id = EnumHelper.EnumParse<ApprovalStatus>(approval);
                approvalStatusCollection.Add(approvalStatusDTO);
            }

            return Ok(approvalStatusCollection);
        }

        // GET: api/<ApprovalStatusController>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           return Ok(EnumHelper.EnumToString<ApprovalStatus>(id));
        }

    }
}

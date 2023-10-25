using AIRegister.DTOs;
using BusinessLogic.Classes;
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
        public IEnumerable<ApprovalDTO>  Get()
        {
           
            ApprovalStatusCollectionDTO approvalStatusCollectionDTO = new ApprovalStatusCollectionDTO();
            foreach (string approval in EnumHelper.EnumToList<AIRegisterEnum.ApprovalStatus>())
            {
                ApprovalDTO approvalStatusDTO = new ApprovalDTO();
                approvalStatusDTO.Name = approval;
                approvalStatusDTO.id = EnumHelper.EnumParse<AIRegisterEnum.ApprovalStatus>(approval);
                approvalStatusCollectionDTO.ApprovalStatuses.Add(approvalStatusDTO);
                
            }

            return approvalStatusCollectionDTO.ApprovalStatuses;

          
        }

        // GET: api/<ApprovalStatusController>
        [HttpGet("{id}")]
        public string Get(int id)
        {
           return EnumHelper.EnumToString<AIRegisterEnum.ApprovalStatus>(id);
        }

    }
}

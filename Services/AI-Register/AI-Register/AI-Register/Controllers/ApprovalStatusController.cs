﻿using AIRegister.DTOs;
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
        public IEnumerable<EnumDTO>  Get()
        {
           
            List<EnumDTO> approvalStatusCollection = new List<EnumDTO>();
            foreach (string approval in EnumHelper.EnumToList<AIRegisterEnum.ApprovalStatus>())
            {
                EnumDTO approvalStatusDTO = new EnumDTO();
                approvalStatusDTO.Name = approval;
                approvalStatusDTO.id = EnumHelper.EnumParse<AIRegisterEnum.ApprovalStatus>(approval);
                approvalStatusCollection.Add(approvalStatusDTO);
                
            }

            return approvalStatusCollection;
        }

        // GET: api/<ApprovalStatusController>
        [HttpGet("{id}")]
        public string Get(int id)
        {
           return EnumHelper.EnumToString<AIRegisterEnum.ApprovalStatus>(id);
        }

    }
}

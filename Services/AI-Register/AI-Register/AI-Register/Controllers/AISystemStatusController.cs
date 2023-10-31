﻿using AIRegister.DTOs;
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
        public IEnumerable<EnumDTO> Get()
        {
            List<EnumDTO> aiSystemStatusEnumCollection = new List<EnumDTO>();
            foreach (string status in EnumHelper.EnumToList<AIRegisterEnum.AISystemStatus>())
            {
                EnumDTO aiSystemStatusEnum = new EnumDTO();
                aiSystemStatusEnum.Name = status;
                aiSystemStatusEnum.id = EnumHelper.EnumParse<AIRegisterEnum.AISystemStatus>(status);
                aiSystemStatusEnumCollection.Add(aiSystemStatusEnum);

            }

            return aiSystemStatusEnumCollection;
        }

        // GET api/<AISystemStatus>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return EnumHelper.EnumToString<AIRegisterEnum.AISystemStatus>(id);
        }

    }
}

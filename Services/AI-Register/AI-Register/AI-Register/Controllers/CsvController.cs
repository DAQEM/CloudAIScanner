using AIRegister.DTOs;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Classes;
using BusinessLogic.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        // POST api/<ValuesController>
        [HttpPost]
        public FileContentResult Post([FromBody] List<CreateCsvDTO> AISystemList)
        {
            var csvAiSystemCreationObjectList = CsvAiSystemCreationObjectList(AISystemList);
            Byte[] content = CsvService.FileContentResult(csvAiSystemCreationObjectList);
            return File(content, "text/csv", "AISystemList.csv");
        }

        private static List<CsvAiSystemCreationObject> CsvAiSystemCreationObjectList(List<CreateCsvDTO> AISystemList)
        {
            CsvAiSystemCreationObject csvAiSystemCreationObject = new CsvAiSystemCreationObject();
            List<CsvAiSystemCreationObject> csvAiSystemCreationObjectList = new List<CsvAiSystemCreationObject>();
            foreach (CreateCsvDTO createCsvDTO in AISystemList)
            {
                csvAiSystemCreationObject = new CsvAiSystemCreationObject();
                csvAiSystemCreationObject.Id = createCsvDTO.Id;
                csvAiSystemCreationObject.Name = createCsvDTO.Name;
                csvAiSystemCreationObject.Description = createCsvDTO.Description;
                csvAiSystemCreationObject.ApprovalStatusName = createCsvDTO.ApprovalStatusName;
                csvAiSystemCreationObject.UnambiguousReference = createCsvDTO.UnambiguousReference;
                csvAiSystemCreationObject.DateAdded = createCsvDTO.DateAdded;
                csvAiSystemCreationObject.ProviderName = createCsvDTO.ProviderName;
                csvAiSystemCreationObjectList.Add(csvAiSystemCreationObject);
            }

            return csvAiSystemCreationObjectList;
        }
    }
}

using AIRegister.DTOs;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Classes;
using BusinessLogic.Services;
using BusinessLogic.Interfaces;
using Microsoft.DotNet.Scaffolding.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AIRegister.Controllers
{
    [Route("api/AISystem/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly CsvService _csvService;

        public CsvController(IProviderRepository provider, IAISystemRepository aiSystemRepository)
        {
            _csvService = new CsvService(provider, aiSystemRepository);

        }

        // POST api/AISystem/<ValuesController>
        [HttpPost]
        public FileContentResult Post([FromBody] List<CreateCsvDTO> AISystemList)
        {
            var csvAiSystemCreationObjectList = CsvAiSystemCreationObjectList(AISystemList);
            Byte[] content = CsvService.FileContentResult(csvAiSystemCreationObjectList);
     
            return File(content, "text/csv", "AISystemList.csv");
        }

        [HttpGet]
        public async Task<FileContentResult> Get()
        {
            Byte[] content = await _csvService.GetAllFiles();
            return File(content, "text/csv", "AISystemList.csv");
        }

        [HttpGet("{provider}")]

        public async Task<FileContentResult> Get(Guid provider)
        {
            
            Byte[] content = await _csvService.getFileByProvider(provider);
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

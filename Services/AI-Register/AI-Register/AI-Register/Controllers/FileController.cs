using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AIRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private FileService _fileService;

        public FileController(IFileRepository fileRepository)
        {
            _fileService = new FileService(fileRepository);
        }
        // GET: api/File
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/File/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/File
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file, string fileType, Guid aiSystemId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please select a file");
        
            string filePath = Path.Combine("pdfs", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            AISystemFile aiSystemFile = new AISystemFile(filePath, fileType);
            AISystemFile returnAiSystemFile = await _fileService.AddAiSystemFile(aiSystemFile, aiSystemId);
            return Created(new Uri(Request.GetDisplayUrl()), returnAiSystemFile);
        }

        // DELETE: api/File/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

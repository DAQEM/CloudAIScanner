using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
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
        
    }
}

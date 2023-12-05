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
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            AISystemFile aiSystemFile = await _fileService.GetAiSystemFile(id);
            if (aiSystemFile == null)
            {return NotFound();}
            Stream stream = new FileStream(aiSystemFile.Filepath, FileMode.Open);
            if (stream == null)
            {
                return NotFound();
            }
            HttpContext.Response.Headers["Content-Disposition"] = $"inline; filename={stream}";
            HttpContext.Response.Headers["Content-Type"] = "application/pdf";
            return File(stream, "application/pdf", aiSystemFile.Filepath);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            AISystemFile aiSystemFile = await _fileService.DeleteAiSystemFile(id);
            if (aiSystemFile == null)
            {return NotFound();}
            System.IO.File.Delete(aiSystemFile.Filepath);
            return Ok();
        }
    }
}

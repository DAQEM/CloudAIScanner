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
            
            string folderPath = Path.Combine("files", aiSystemId.ToString());
            Directory.CreateDirectory(folderPath);
            
            string filePath = Path.Combine(folderPath, file.FileName);
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
            {
                return NotFound();
            }

            Stream stream = new FileStream(aiSystemFile.Filepath, FileMode.Open);
            if (stream == null)
            {
                return NotFound();
            }

            string extension = System.IO.Path.GetExtension(aiSystemFile.Filepath);
            string contentType = "";
            switch (extension)
            {
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".txt":
                    contentType = "text/plain";
                    break;
                case ".doc":
                case ".docx":
                case ".docm":
                    contentType = "application/msword";
                    break;
                case ".xls":
                case ".xlsx":
                case ".xlsm":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".ppt":
                case ".pptx":
                case ".pptm":
                    contentType = "application/vnd.ms-powerpoint";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }
            string fileName = Path.GetFileName(aiSystemFile.Filepath);
            HttpContext.Response.Headers["Content-Disposition"] = $"inline; filename={stream}";
            HttpContext.Response.Headers["Content-Type"] = contentType;
            return File(stream, contentType, fileName);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            AISystemFile aiSystemFile = await _fileService.DeleteAiSystemFile(id);
            if (aiSystemFile == null)
            {return NotFound();}
            System.IO.File.Delete(aiSystemFile.Filepath);
            string folderPath = Path.GetDirectoryName(aiSystemFile.Filepath);
            if (Directory.GetFiles(folderPath).Length == 0)
            {
                Directory.Delete(folderPath);
            }
            return Ok();
        }
    }
}

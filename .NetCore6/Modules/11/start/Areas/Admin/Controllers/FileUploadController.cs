using Microsoft.AspNetCore.Authorization;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class FileUploadController : Controller
    {
        private readonly IConfiguration Configuration;
        

        public FileUploadController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Admin/FileUpload")]
        public async Task<IActionResult> FileUploadAsync(IFormFile uploadFile)
        {
            if (uploadFile == null || uploadFile.Length == 0)
            {
                ModelState.AddModelError("File", string.Format("Invalid file"));
                return View("index");  
            }

            await SaveFile(uploadFile);

            return View("index");  
        }

        private const string UploadPath = "Uploads/";

        private async Task SaveFile(IFormFile uploadFile)
        {
            var filePath = UploadPath + uploadFile.FileName;

            using (var stream = System.IO.File.Create(filePath))
            {
                await uploadFile.CopyToAsync(stream);
            }            
        }
    }
}
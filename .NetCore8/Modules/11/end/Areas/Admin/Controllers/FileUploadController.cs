using Globomantics.Survey.Services;
using Microsoft.AspNetCore.Authorization;
using nClam;

namespace Globomantics.Survey.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class FileUploadController : Controller
    {

        private readonly IConfiguration Configuration;
        private readonly FileValidationService _fileValidationService;
        private readonly long MaxFileSizeBytes = 0;
        private readonly string AntiVirusHost = "";
        private readonly int AntiVirusPort = 0;

        public FileUploadController(IConfiguration configuration,
            FileValidationService fileValidationService)
        {
            Configuration = configuration;
            _fileValidationService = fileValidationService;
            MaxFileSizeBytes = Convert.ToInt64(Configuration["MaxFileSize"]);
            AntiVirusHost = Configuration["AntiVirus:Host"];
            AntiVirusPort = Convert.ToInt32(Configuration["AntiVirus:Port"]);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Admin/FileUpload")]
        public async Task<IActionResult> FileUploadAsync(IFormFile uploadFile)
        {
            if (!ModelState.IsValid)
                return View("Index");  

            if (uploadFile == null || uploadFile.Length == 0)
            {
                ModelState.AddModelError("File", string.Format("Invalid file"));
                return View("index");  
            }

            if (uploadFile.Length > MaxFileSizeBytes)
            {
                ModelState.AddModelError("File", string.Format("The file is too large. It cannot be above {0} bytes", MaxFileSizeBytes));
                return View("Index");    
            }

            if (!_fileValidationService.IsValid(uploadFile))
            {
                ModelState.AddModelError("File", string.Format("File type is invalid"));
                return View("Index"); 
            }

            var scanResult = await VirusScan(uploadFile);

            switch (scanResult.Result)  
            {  
                case ClamScanResults.Clean:  
                    await SaveFile(uploadFile);
                    break;
                case ClamScanResults.VirusDetected:  
                    ModelState.AddModelError("File", "The file contains a virus!");
                    break;  
                default:  
                    ModelState.AddModelError("File", "An error was encountered while scanning the file");
                    break;  
            }  

            return View("index"); 
        }

        private const string UploadPath = "Uploads/";

        private async Task SaveFile(IFormFile uploadFile)
        {
            var filePath = UploadPath + Path.GetRandomFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await uploadFile.CopyToAsync(stream);
            }            
        }

        private async Task<ClamScanResult> VirusScan(IFormFile uploadFile)
        {
            var clam = new ClamClient(AntiVirusHost, AntiVirusPort);

            var memoryStream = new MemoryStream();  
            uploadFile.OpenReadStream().CopyTo(memoryStream);  
            byte[] fileBytes = memoryStream.ToArray(); 

            return await clam.SendAndScanFileAsync(fileBytes); 
        }
    }
}
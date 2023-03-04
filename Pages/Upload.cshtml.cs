using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Raindish.FileUploadService;
using Raindish._01.FileUploadService;

namespace Raindish._01.Pages
{
    public class UploadModel : PageModel
    {
        private readonly ILogger<UploadModel> _logger;
        private readonly IFileUploadService _fileUploadService;

        public string FilePath;
        public UploadModel(ILogger <UploadModel> logger, IFileUploadService fileUploadService)
        {
            _logger = logger;
            _fileUploadService = fileUploadService;
        }
        public void OnGet()
        {
        }
        public async Task<PageResult> OnPost(IFormFile file) 
        { 
        try { 
                if (await _fileUploadService.UploadFileAsync(file))
                {
                   ViewData["Message"] = "File Uploaded Successfully";
               }
               else
               {
                   ViewData["Message"] = "File Upload Failed";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Upload Failed");
                ViewData["Message"] = "File Upload Failed";
            }
            return Page();
        }
    }
}


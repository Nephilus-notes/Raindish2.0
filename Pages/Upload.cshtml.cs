using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Raindish.FileUploadService;

namespace Raindish._01.Pages
{
    public class UploadModel : PageModel
    {
        private readonly ILogger<UploadModel> _logger;
        private readonly LocalFileUploadService _fileUploadService;

        public string FilePath;
        public UploadModel(ILogger <UploadModel> logger, LocalFileUploadService fileUploadService)
        {
            _logger = logger;
            _fileUploadService = fileUploadService;
        }
        public void OnGet()
        {
        }
        public async void OnPost(IFormFile file) 
        { 
        if (file != null)
            {
                FilePath = await _fileUploadService.UploadFileAsync(file);
            }
        }
    }
}

using Raindish._01.FileUploadService;

namespace Raindish.FileUploadService
{
    public class LocalFileUploadService: IFileUploadService
    {
        public async Task<bool> UploadFileAsync(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length> 0 )
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path) )
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}

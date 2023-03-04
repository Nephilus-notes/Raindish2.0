namespace Raindish._01.FileUploadService
{
    public interface IFileUploadService
    {
        Task<bool> UploadFileAsync(IFormFile file);
    }
}
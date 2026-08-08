namespace BharathSchool.Web.Services
{
    public interface IFileUploadService
    {
        Task<(bool Success, string FilePath, string Message)> UploadFileAsync(IFormFile file, string uploadPath, string[] allowedExtensions, long maxFileSize);
        bool DeleteFile(string filePath);
        Task<byte[]> GetFileAsync(string filePath);
    }
}

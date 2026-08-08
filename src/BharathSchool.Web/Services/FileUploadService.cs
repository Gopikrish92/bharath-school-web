namespace BharathSchool.Web.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;

        public FileUploadService(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            _configuration = configuration;
        }

        public async Task<(bool Success, string FilePath, string Message)> UploadFileAsync(
            IFormFile file, string uploadPath, string[] allowedExtensions, long maxFileSize)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return (false, string.Empty, "No file provided.");

                // Validate file size
                if (file.Length > maxFileSize)
                    return (false, string.Empty, $"File size exceeds {maxFileSize / (1024 * 1024)}MB limit.");

                // Validate extension
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                    return (false, string.Empty, $"File type '{extension}' is not allowed.");

                // Create upload directory if it doesn't exist
                var uploadDir = Path.Combine(_environment.WebRootPath, uploadPath);
                Directory.CreateDirectory(uploadDir);

                // Generate unique filename
                var fileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadDir, fileName);

                // Save file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return relative path for database storage
                var relativePath = $"/{uploadPath.Replace("\\", "/")}/{fileName}";
                return (true, relativePath, "File uploaded successfully.");
            }
            catch (Exception ex)
            {
                return (false, string.Empty, $"Error uploading file: {ex.Message}");
            }
        }

        public bool DeleteFile(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    return false;

                var fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<byte[]> GetFileAsync(string filePath)
        {
            try
            {
                var fullPath = Path.Combine(_environment.WebRootPath, filePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    return await File.ReadAllBytesAsync(fullPath);
                }
                return Array.Empty<byte>();
            }
            catch
            {
                return Array.Empty<byte>();
            }
        }
    }
}

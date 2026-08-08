using Microsoft.AspNetCore.Identity;

namespace BharathSchool.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string ProfilePhotoPath { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.ViewModels
{
    public class ManageProfileViewModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public IFormFile ProfilePhoto { get; set; }

        public string CurrentPhotoPath { get; set; } = string.Empty;
    }
}

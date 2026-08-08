using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.ViewModels
{
    public class ActivityCreateViewModel
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ActivityType { get; set; } = string.Empty;

        public DateTime? ActivityDate { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        public List<IFormFile> MediaFiles { get; set; } = new List<IFormFile>();
    }
}

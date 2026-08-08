using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.ViewModels
{
    public class LeaveRequestViewModel
    {
        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Reason { get; set; } = string.Empty;
    }
}

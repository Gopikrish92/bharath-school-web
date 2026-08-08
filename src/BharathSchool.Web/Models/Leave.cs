using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Leave
    {
        public int LeaveId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [MaxLength(1000)]
        public string Reason { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Status { get; set; } = "Pending"; // Pending/Approved/Rejected

        public Guid? ApproverId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int GetNumberOfDays() => (int)(ToDate - FromDate).TotalDays + 1;
    }
}

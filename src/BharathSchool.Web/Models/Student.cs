using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Student
    {
        public Guid StudentId { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;

        public DateTime? DOB { get; set; }

        [MaxLength(20)]
        public string Gender { get; set; } = string.Empty;

        [MaxLength(512)]
        public string PhotoPath { get; set; } = string.Empty;

        public int? StandardId { get; set; }
        public int? SectionId { get; set; }

        [MaxLength(50)]
        public string AdmissionStatus { get; set; } = "Inactive";

        [MaxLength(1000)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(300)]
        public string ParentName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ParentContact { get; set; } = string.Empty;

        public int? BusRouteId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("StandardId")]
        public Standard Standard { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}


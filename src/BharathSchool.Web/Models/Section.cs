using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Section
    {
        public int SectionId { get; set; }

        [Required]
        public int StandardId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int? Capacity { get; set; }

        [ForeignKey("StandardId")]
        public Standard Standard { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

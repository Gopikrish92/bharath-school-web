using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        public ICollection<Standard> Standards { get; set; } = new List<Standard>();
    }
}

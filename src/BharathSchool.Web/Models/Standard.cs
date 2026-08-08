using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class Standard
    {
        public int StandardId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(512)]
        public string PhotoPath { get; set; } = string.Empty;

        public int Order { get; set; }

        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}

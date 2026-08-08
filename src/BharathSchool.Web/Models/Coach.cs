using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class Coach
    {
        public int CoachId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Contact { get; set; } = string.Empty;

        [MaxLength(512)]
        public string PhotoPath { get; set; } = string.Empty;

        public ICollection<Sport> Sports { get; set; } = new List<Sport>();
    }
}

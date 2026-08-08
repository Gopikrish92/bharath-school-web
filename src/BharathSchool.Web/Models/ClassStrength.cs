using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class ClassStrength
    {
        public int ClassStrengthId { get; set; }

        public int StandardId { get; set; }

        public int? SectionId { get; set; }

        public int StudentCount { get; set; }

        [ForeignKey("StandardId")]
        public Standard Standard { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}


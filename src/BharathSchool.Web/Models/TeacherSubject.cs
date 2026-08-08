using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class TeacherSubject
    {
        public int TeacherSubjectId { get; set; }

        public Guid TeacherId { get; set; }

        public int SubjectId { get; set; }

        public int? StandardId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        [ForeignKey("StandardId")]
        public Standard Standard { get; set; }
    }
}

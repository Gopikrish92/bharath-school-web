using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Teacher
    {
        public Guid TeacherId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [MaxLength(150)]
        public string Designation { get; set; } = string.Empty;

        public DateTime? JoiningDate { get; set; }

        [MaxLength(512)]
        public string PhotoPath { get; set; } = string.Empty;

        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }
}

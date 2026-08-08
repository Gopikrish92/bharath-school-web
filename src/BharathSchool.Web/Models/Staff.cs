using System;
using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class Staff
    {
        public Guid StaffId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; }

        [MaxLength(150)]
        public string Position { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Posting { get; set; } = string.Empty;

        [MaxLength(512)]
        public string PhotoPath { get; set; } = string.Empty;
    }
}

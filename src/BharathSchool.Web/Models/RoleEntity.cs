using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class RoleEntity
    {
        public int RoleEntityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}

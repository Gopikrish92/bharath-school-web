using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class SiteSetting
    {
        [Key]
        [MaxLength(200)]
        public string SettingKey { get; set; } = string.Empty;

        [MaxLength(4000)]
        public string SettingValue { get; set; } = string.Empty;
    }
}

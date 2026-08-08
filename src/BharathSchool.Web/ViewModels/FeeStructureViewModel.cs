using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.ViewModels
{
    public class FeeStructureViewModel
    {
        public int FeeId { get; set; }

        [Required]
        public int StandardId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Term { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal TuitionFee { get; set; }

        [Range(0, double.MaxValue)]
        public decimal BookFee { get; set; }

        [Range(0, double.MaxValue)]
        public decimal UniformFee { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ShoesFee { get; set; }

        [Range(0, double.MaxValue)]
        public decimal SportsDressFee { get; set; }

        [Range(0, double.MaxValue)]
        public decimal BusFee { get; set; }

        [MaxLength(1000)]
        public string OtherFees { get; set; } = string.Empty;
    }
}

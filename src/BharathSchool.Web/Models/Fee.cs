using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class Fee
    {
        public int FeeId { get; set; }

        [Required]
        public int StandardId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Term { get; set; } = string.Empty;

        public decimal TuitionFee { get; set; }
        public decimal BookFee { get; set; }
        public decimal UniformFee { get; set; }
        public decimal ShoesFee { get; set; }
        public decimal SportsDressFee { get; set; }
        public decimal BusFee { get; set; }

        [MaxLength(1000)]
        public string OtherFees { get; set; } = string.Empty;

        [ForeignKey("StandardId")]
        public Standard Standard { get; set; }

        public decimal GetTotalFee() => TuitionFee + BookFee + UniformFee + ShoesFee + SportsDressFee + BusFee;
    }
}

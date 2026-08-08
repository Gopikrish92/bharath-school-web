using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BharathSchool.Web.Models
{
    public class BusStop
    {
        public int BusStopId { get; set; }

        [Required]
        public int BusRouteId { get; set; }

        [Required]
        [MaxLength(250)]
        public string StopName { get; set; } = string.Empty;

        public int? PickupOrder { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        [ForeignKey("BusRouteId")]
        public BusRoute BusRoute { get; set; }
    }
}

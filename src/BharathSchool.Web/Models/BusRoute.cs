using System.ComponentModel.DataAnnotations;

namespace BharathSchool.Web.Models
{
    public class BusRoute
    {
        public int BusRouteId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        public ICollection<BusStop> BusStops { get; set; } = new List<BusStop>();
    }
}

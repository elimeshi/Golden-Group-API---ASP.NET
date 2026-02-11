using System.Collections.Generic;

namespace GoldenGroupAPI.Models
{
    public class HousingUnit
    {
        public int Id { get; set; }
        public double SquaredMeters { get; set; }
        public double Rooms { get; set; }
        public int Floor { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        // Relation to Listing
        public int ListingId { get; set; }
    }
}

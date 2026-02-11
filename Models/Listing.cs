using System;
using System.Collections.Generic;
using GoldenGroupAPI.Models.Enums;

namespace GoldenGroupAPI.Models
{
    public abstract class Listing
    {
        public int Id { get; set; }
        public string City { get; set; } = "ביתר עילית";
        public string Street { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string AptNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public double Rooms { get; set; }
        public double SquaredMeters { get; set; }
        public Zone Zone { get; set; }
        public decimal Price { get; set; }
        
        // Seller details
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public DateTime EnteringDate { get; set; }
        public DateTime ApplicationDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;
        public PropertyState PropertyState { get; set; }
        public string Details { get; set; } = string.Empty;

        public List<HousingUnit> HousingUnits { get; set; } = new List<HousingUnit>();
    }

    public class NormalListing : Listing
    {
        // No additional properties for NormalListing based on requirements
    }

    public class TaboListing : Listing
    {
        public RegistrationType RegistrationType { get; set; }
        public int NumOfPartners { get; set; }
        public decimal RequiredEquity { get; set; }
    }
}

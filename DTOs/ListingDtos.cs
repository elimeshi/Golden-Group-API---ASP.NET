using System;
using System.Collections.Generic;
using GoldenGroupAPI.Models.Enums;

namespace GoldenGroupAPI.DTOs
{
    public abstract class ListingDto
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string AptNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public double Rooms { get; set; }
        public double SquaredMeters { get; set; }
        public string Zone { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int ClientId { get; set; }
        public DateTime EnteringDate { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string PropertyState { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public List<HousingUnitDto> HousingUnits { get; set; } = new List<HousingUnitDto>();
    }

    public class NormalListingDto : ListingDto { }

    public class TaboListingDto : ListingDto
    {
        public string RegistrationType { get; set; } = string.Empty;
        public int NumOfPartners { get; set; }
        public decimal RequiredEquity { get; set; }
    }

    public class HousingUnitDto
    {
        public double SquaredMeters { get; set; }
        public double Rooms { get; set; }
        public int Floor { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public abstract class CreateListingDto
    {
        public string City { get; set; } = "ביתר עילית";
        public string Street { get; set; } = string.Empty;
        public string BuildingNumber { get; set; } = string.Empty;
        public string AptNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public double Rooms { get; set; }
        public double SquaredMeters { get; set; }
        public Zone Zone { get; set; }
        public decimal Price { get; set; }
        public int ClientId { get; set; }
        public DateTime EnteringDate { get; set; }
        public PropertyState PropertyState { get; set; }
        public string Details { get; set; } = string.Empty;
        public List<HousingUnitDto> HousingUnits { get; set; } = new List<HousingUnitDto>();
    }

    public class CreateNormalListingDto : CreateListingDto { }

    public class CreateTaboListingDto : CreateListingDto
    {
        public RegistrationType RegistrationType { get; set; }
        public int NumOfPartners { get; set; }
        public decimal RequiredEquity { get; set; }
    }

    public class UpdateListingDto : CreateListingDto { }
}

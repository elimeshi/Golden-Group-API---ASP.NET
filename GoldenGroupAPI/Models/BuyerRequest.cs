using System.Collections.Generic;
using GoldenGroupAPI.Models.Enums;

namespace GoldenGroupAPI.Models
{
    public abstract class BuyerRequest
    {
        public int Id { get; set; }
        public List<Zone> Zones { get; set; } = new List<Zone>();
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }
        public decimal MaxPrice { get; set; }
        public double MinSize { get; set; }
        public string Details { get; set; } = string.Empty;
        public Liquidity Liquidity { get; set; }

        // Buyer details
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }

    public class NormalBuyerRequest : BuyerRequest
    {
        // No additional properties for NormalBuyerRequest
    }

    public class TaboBuyerRequest : BuyerRequest
    {
        public decimal MaxEquity { get; set; }
        public Community Community { get; set; }
        public RegistrationType RegistrationType { get; set; }
        public int MaxPartners { get; set; }
    }
}

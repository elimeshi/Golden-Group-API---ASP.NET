using System.Collections.Generic;
using GoldenGroupAPI.Models.Enums;

namespace GoldenGroupAPI.DTOs
{
    public abstract class BuyerRequestDto
    {
        public int Id { get; set; }
        public List<string> Zones { get; set; } = new List<string>();
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }
        public decimal MaxPrice { get; set; }
        public double MinSize { get; set; }
        public string Details { get; set; } = string.Empty;
        public string Liquidity { get; set; } = string.Empty;
        public int ClientId { get; set; }
    }

    public class NormalBuyerRequestDto : BuyerRequestDto { }

    public class TaboBuyerRequestDto : BuyerRequestDto
    {
        public decimal MaxEquity { get; set; }
        public string Community { get; set; } = string.Empty;
        public string RegistrationType { get; set; } = string.Empty;
        public int MaxPartners { get; set; }
    }

    public abstract class CreateBuyerRequestDto
    {
        public List<Zone> Zones { get; set; } = new List<Zone>();
        public int MinFloor { get; set; }
        public int MaxFloor { get; set; }
        public decimal MaxPrice { get; set; }
        public double MinSize { get; set; }
        public string Details { get; set; } = string.Empty;
        public Liquidity Liquidity { get; set; }
        public int ClientId { get; set; }
    }

    public class CreateNormalBuyerRequestDto : CreateBuyerRequestDto { }

    public class CreateTaboBuyerRequestDto : CreateBuyerRequestDto
    {
        public decimal MaxEquity { get; set; }
        public Community Community { get; set; }
        public RegistrationType RegistrationType { get; set; }
        public int MaxPartners { get; set; }
    }

    public class UpdateBuyerRequestDto : CreateBuyerRequestDto { }
}

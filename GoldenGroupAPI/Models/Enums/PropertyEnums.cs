namespace GoldenGroupAPI.Models.Enums
{
    public enum Zone
    {
        ZoneA,
        ZoneB,
        ZoneC,
        Beitar_A,
        Beitar_B,
        Beitar_C
    }

    public enum PropertyState
    {
        NewFromContractor,
        New,
        Renovated,
        GoodCondition,
        NeedsRenovation
    }

    public enum RegistrationType
    {
        Tabo,
        Company,
        Other
    }

    public enum Liquidity
    {
        Immediate,
        High,
        Medium,
        Low
    }

    public enum Community
    {
        Haredi,
        Secular,
        Mixed
    }
}

namespace Brandscreen.Core.Services.Deals
{
    public enum DealModeEnum
    {
        ExchangeDeal = 1,
        DirectBuyDeal = 2
    }

    /// <summary>
    /// Exchange or Data Partner
    /// </summary>
    public enum PartnerEnum
    {
        Google = 1,
        Rubicon = 2,
        Pubmatic = 3,
        AppNexus = 5,
        AdMeld = 6,
        OpenX = 7,
        Facebook = 8,
        Adaptv = 9,
        PulsePoint = 11,
        BrandscreenForPublishers = 12,
        SpotXchange = 13,
        YieldOne = 15,
        OpenXJapan = 16,
        MoPub = 17,
        Peer39 = 18,
        Proximic = 19,
        Adiquity = 20,
        Taobao = 21,
        AdChina = 22,
        Integral = 67,
        LiveRail = 77,
        SiteTour = 68
    }

    public enum DealTypeEnum
    {
        /// <summary>
        /// Fixed Price: Will only show one numeral only field where the user can specify a fixed price for a deal.
        /// </summary>
        Fixed = 1,

        /// <summary>
        /// Second Price: Will show two numeral only fields, where a user can specify a floor and ceiling price.
        /// </summary>
        Floor = 2
    }
}
namespace Brandscreen.Core.Services.Brands
{
    public enum SiteListOptionEnum
    {
        AllSites = 1,
        BrandscreenBlacklist = 2,
        BrandscreenWhitelist = 3,
        CustomWhitelist = 4
    }

    public enum BrandSafetyModeEnum
    {
        RunOnAllSites = 0,
        CortexBlacklist = 1,
        CortexWhiteList = 2,
        CustomWhiteList = 3,
        PageLevelSafety = 4
    }
}
using System;

namespace Brandscreen.Analytics.Entities
{
    public interface IAdGroupAnalyticsData
    {
        int BuyerAccountId { get; set; }
        int AdvertiserId { get; set; }
        int AdvertiserProductId { get; set; }
        int CampaignId { get; set; }
        int AdGroupId { get; set; }
        DateTime LocalDate { get; set; }
    }

    public partial class AdAnalyticsReportId : IAdGroupAnalyticsData
    {
    }
}
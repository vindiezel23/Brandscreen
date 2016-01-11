namespace Brandscreen.Core.Services.Campaigns
{
    public enum CampaignStatusEnum
    {
        Pending = 1, // The campaign is pending
        Live = 2, // The campaign is enabled and running
        Paused = 3, // The campaign has been paused
        Completed = 4, // The campaign has completed its goal
        Deleted = 5, // The campaign has been deleted
        Suspended = 6, // The campaign has been suspended by the system
        Draft = 7, // Draft status for Ad (Creative)
    }
}
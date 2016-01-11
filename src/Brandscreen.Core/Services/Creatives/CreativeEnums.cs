namespace Brandscreen.Core.Services.Creatives
{
    public enum CreativeTypeEnum
    {
        Unspecified = 0,
        Image = 1,
        Flash = 2,
        Video = 3,
        Facebook = 4,
        Outlook = 5,
        Dooh = 6,
        Html5 = 7
    }

    public enum CreativeStatusEnum
    {
        Live = 2,
        Draft = 7
    }

    public enum CreativeThumbnailStatusEnum
    {
        New = 0, // File is uploaded but no thumbnails generated
        Generated = 1,
        Processing = 2,
        TimedOut = 3, // Timeout during thumbnail processing
        UsesGeneric = 4,
        Failed = 5 // Error occured
    }

    public enum ExpandableDirectionEnum
    {
        None = 0,
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4,
        UpLeft = 5,
        UpRight = 6,
        DownLeft = 7,
        DownRight = 8
    }

    public enum CreativeReviewStatusEnum
    {
        Approved = 0,
        Reviewing = 1,
        Ready = 2,
        Rejected = 3,
        Canceled = 8,
    }
}
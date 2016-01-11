namespace Brandscreen.Core.Services.Segments
{
    /// <summary>
    /// Segment Type
    /// </summary>
    public enum SegmentTypeEnum
    {
        /// <summary>
        /// Conversion segment
        /// </summary>
        Conversion = 1,

        /// <summary>
        /// Remarketing segment
        /// </summary>
        Remarketing = 2,

        /// <summary>
        /// Subscription segment
        /// </summary>
        ThirdParty = 3,

        /// <summary>
        /// First party conversion segment
        /// </summary>
        FirstPartyConversion = 4,

        /// <summary>
        /// Second party conversion segment
        /// </summary>
        SecondPartyConversion = 5,

        /// <summary>
        /// First party remarketing segment
        /// </summary>
        FirstPartyRemarketing = 6,

        /// <summary>
        /// Second party remarketing segment
        /// </summary>
        SecondPartyRemarketing = 7
    }

    public enum ConversionAttributionModelEnum
    {
        /// <summary>
        /// Last entry in path gets credit
        /// </summary>
        LastEntryInPath = 1,

        /// <summary>
        /// Last click in path gets credit
        /// </summary>
        LastClick = 2
    }

    public enum ConversionAttributionCountingModeEnum
    {
        /// <summary>
        /// Count every event
        /// </summary>
        EveryEvent = 1,

        /// <summary>
        /// Count one event per session
        /// </summary>
        OncePerSession = 2,

        /// <summary>
        /// Count one event per a specified time period in Recency
        /// </summary>
        OncePerRecency = 3,

        /// <summary>
        /// Count one event only
        /// </summary>
        OncePerLifetime = 4
    }
}
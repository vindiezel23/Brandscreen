namespace Brandscreen.Core.Services.Strategies
{
    public enum UniqueConstraintPeriodEnum
    {
        PerMinute = PeriodTypeEnum.PerMinute,
        PerHour = PeriodTypeEnum.PerHour,
        PerDay = PeriodTypeEnum.PerDay,
        PerWeek = PeriodTypeEnum.PerWeek,
        PerMonth = PeriodTypeEnum.PerMonth,
    }

    public enum StrategyTypeEnum
    {
        SingleFlight = PeriodTypeEnum.Total,
        OngoingWeekly = PeriodTypeEnum.PerWeek,
        OngoingMonthly = PeriodTypeEnum.PerMonth
    }

    public enum FlightTypeEnum
    {
        SingleFlight = PeriodTypeEnum.Total,
        OngoingWeekly = PeriodTypeEnum.PerWeek,
        OngoingMonthly = PeriodTypeEnum.PerMonth
    }

    public enum PeriodTypeEnum
    {
        /// <summary>
        /// Per hour
        /// </summary>
        PerHour = 0,

        /// <summary>
        /// Per day
        /// </summary>
        PerDay = 1,

        /// <summary>
        /// Per week
        /// </summary>
        PerWeek = 2,

        /// <summary>
        /// Per month
        /// </summary>
        PerMonth = 3,

        /// <summary>
        /// Total
        /// </summary>
        Total = 4,

        /// <summary>
        /// Per minute
        /// </summary>
        PerMinute = 5,
    }

    public enum TargetingActionEnum
    {
        Unspecified = 0,
        Avoiding = 1,
        Targeting = 2,
        Mixed = 3,
        Completed = 4,
        Inactive = 5,
        TargetingOverride = 6,
        CortexAvoided = 7
    }

    public enum SupplySourceEnum
    {
        PublicMarket = 1,
        PrivateMarket = 2
    }

    /// <summary>
    /// What type of goal is aiming to be achieved?
    /// </summary>
    public enum GoalTypeEnum
    {
        /// <summary>
        /// Aim to achieve an efficient delivery of impressions
        /// </summary>
        Impressions = 1,

        /// <summary>
        /// Aim to deliver a high CTR (low CPC)
        /// </summary>
        Clicks = 2,

        /// <summary>
        /// Aim to deliver a high Conv% (low CPA)
        /// </summary>
        Actions = 3,

        /// <summary>
        /// Aim to maximise time in-view (low CPMS)
        /// </summary>
        ViewDuration = 4,

        /// <summary>
        /// Aim to maximise time of slot (low CPMS)
        /// </summary>
        SlotDuration = 5
    }

    public enum MediaTypeEnum
    {
        Display = 1,
        Video = 2,
        Mobile = 3,
        Facebook = 4,
        Dooh = 5
    }

    public enum PacingStyleEnum
    {
        Unrestrained = 1,
        Evenly = 2,
        Fixed = 3
    }

    public enum PacingStyleEvenlyModeEnum
    {
        Behind = 1,
        Normal = 2,
        Ahead = 3,
        Aggressive = 4
    }
}
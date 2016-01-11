using System;
using Brandscreen.Core.Services.Users;
using NodaTime;

namespace Brandscreen.Core.Services.Strategies
{
    public static class IntervalExtensions
    {
        /// <summary>
        /// Coverts strategy type to time span
        /// </summary>
        public static TimeSpanEnum ToTimeSpan(this StrategyTypeEnum strategyType)
        {
            switch (strategyType)
            {
                case StrategyTypeEnum.SingleFlight:
                    return TimeSpanEnum.AllTime;
                case StrategyTypeEnum.OngoingWeekly:
                    return TimeSpanEnum.Last7Days;
                case StrategyTypeEnum.OngoingMonthly:
                    return TimeSpanEnum.Last30Days;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Converts time span to interval (db id)
        /// </summary>
        public static IntervalEnum ToInterval(this TimeSpanEnum timeSpan)
        {
            switch (timeSpan)
            {
                case TimeSpanEnum.Today:
                case TimeSpanEnum.Yesterday:
                case TimeSpanEnum.Last7Days:
                case TimeSpanEnum.Last30Days:
                    return IntervalEnum.Day;
                case TimeSpanEnum.ThisWeek:
                case TimeSpanEnum.LastWeek:
                    return IntervalEnum.Week;
                case TimeSpanEnum.ThisMonth:
                case TimeSpanEnum.LastMonth:
                    return IntervalEnum.Month;
                case TimeSpanEnum.ThisYear:
                case TimeSpanEnum.LastYear:
                    return IntervalEnum.Year;
                case TimeSpanEnum.AllTime:
                    return IntervalEnum.AllTime;
                case TimeSpanEnum.Custom:
                    return IntervalEnum.Custom;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Converts local datetime to interval value basing on interval (db value)
        /// </summary>
        public static int ToIntervalValue(this DateTime localDateTime, IntervalEnum interval)
        {
            var epochStart = new LocalDateTime(2010, 01, 01, 0, 0, 0, 0); // Jan 1, 2010, a Friday
            var epochEnd = LocalDateTime.FromDateTime(localDateTime);

            switch (interval)
            {
                case IntervalEnum.Day:
                case IntervalEnum.Custom:
                    return (int) Period.Between(epochStart, epochEnd, PeriodUnits.Days).Days;
                case IntervalEnum.Week:
                    return ((int) Period.Between(epochStart, epochEnd, PeriodUnits.Days).Days + 5)/7;
                case IntervalEnum.Month:
                    return (int) Period.Between(epochStart, epochEnd, PeriodUnits.Months).Months;
                case IntervalEnum.Year:
                    return (int) Period.Between(epochStart, epochEnd, PeriodUnits.Years).Years;
                case IntervalEnum.AllTime:
                    return 0;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
namespace Brandscreen.Core.Services.Partners
{
    public enum PrivateDealModeEnum
    {
        /// <summary>
        /// None: Private deals are not supported.
        /// </summary>
        None = 0,

        /// <summary>
        /// Fixed Price Only: Fixed Price deal is only supported.
        /// </summary>
        FixedPriceOnly = 1,

        /// <summary>
        /// Fixed And Second Price: Fixed and Second Price both are supported.
        /// </summary>
        FixedAndSecondPrice = 2,

        /// <summary>
        /// Second Price Only: Second Price is only supported.
        /// </summary>
        SecondPriceOnly = 3
    }
}
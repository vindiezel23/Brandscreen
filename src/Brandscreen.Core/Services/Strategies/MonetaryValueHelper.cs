namespace Brandscreen.Core.Services.Strategies
{
    public class MonetaryValueHelper
    {
        /*
         370	Australian Dollar	AUD    400,000
         374	Baht	THB    12,000,000
         411	Dong	VND    8,000,000,000
         429	Hong Kong Dollar	HKD    3,000,000
         432	Indian Rupee	INR    20,000,000
         457	Malaysian Ringgit	MYR    1,200,000
         473	New Taiwan Dollar	TWD    12,000,000
         474	New Zealand Dollar	NZD    400,000
         486	Philippine Peso	PHP    16,000,000
         505	Singapore Dollar	SGD    500,000
         512	Sri Lanka Rupee	LKR    50,000,000
         533	US Dollar	USD    400,000
         540	Won	KRW    450,000,000
         542	Japanese Yen	JPY    40,000,000
         543	Yuan Renminbi	CNY    2,000,000
         416	Euro	EUR    300,000
         488	Pound Sterling	GBP    260,000
         497	Russian Ruble	RUB    12,000,000
         510	Somoni	TJS    1,800,000
         527	UAE Dirham	AED    1,400,000
         546	Zloty	PLN    1,200,000
         */

        /// <summary>
        /// Gets budget limitation by currency id.
        /// </summary>
        public static decimal GetMaxBudgetAmount(int currencyId)
        {
            switch (currencyId)
            {
                case 370:
                    return 400000;
                case 374:
                    return 12000000;
                case 411:
                    return 8000000000;
                case 429:
                    return 3000000;
                case 432:
                    return 20000000;
                case 457:
                    return 1200000;
                case 473:
                    return 12000000;
                case 474:
                    return 400000;
                case 486:
                    return 16000000;
                case 505:
                    return 500000;
                case 512:
                    return 50000000;
                case 533:
                    return 400000;
                case 540:
                    return 450000000;
                case 542:
                    return 40000000;
                case 543:
                    return 2000000;
                case 416:
                    return 300000;
                case 488:
                    return 260000;
                case 497:
                    return 12000000;
                case 510:
                    return 1800000;
                case 527:
                    return 1400000;
                case 546:
                    return 1200000;
                default:
                    return 400000;
            }
        }
    }
}
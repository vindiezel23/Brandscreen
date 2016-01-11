using System;
using System.Collections.Generic;
using Brandscreen.Entities;

namespace Brandscreen.Core.Services.Reports
{
    public class ReportCriteria
    {
        public ReportCriteria()
        {
            BuyerAccounts = new List<BuyerAccount>();
        }

        public ReportTypeEnum Type { get; set; }
        public ReportLevelEnum Level { get; set; }

        public List<BuyerAccount> BuyerAccounts { get; set; }
        public Advertiser Advertiser { get; set; }
        public AdvertiserProduct AdvertiserProduct { get; set; }
        public Campaign Campaign { get; set; }
        public AdGroup AdGroup { get; set; }

        public DateTime? LocalFromDateTime { get; set; }
        public DateTime? LocalToDateTime { get; set; }
    }
}
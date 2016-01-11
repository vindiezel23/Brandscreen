using System;

namespace Brandscreen.Core.Services.Creatives
{
    public class CreativeReviewModifyOptions
    {
        public Guid CreativeUuid { get; set; }
        public CreativeReviewStatusEnum Status { get; set; }
        public int PartnerId { get; set; }
        public int[] RejectionReasonIds { get; set; }
        public string ExchangeErrorString { get; set; }
    }
}
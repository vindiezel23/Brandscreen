using System;

namespace Brandscreen.Core.MiniBuss.Messages
{
    public class GenerateCreativeThumbnailEvent : IMessage
    {
        public Guid[] CreativeUuids { get; set; }
        public bool[] IsThirdParty { get; set; }
        public Guid InitiatingUserId { get; set; }
        public int BuyerAccountId { get; set; }
        public int Attempt { get; set; }
    }
}
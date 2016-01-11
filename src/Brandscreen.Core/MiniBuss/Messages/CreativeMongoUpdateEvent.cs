using System;

namespace Brandscreen.Core.MiniBuss.Messages
{
    public class CreativeMongoUpdateEvent : IMessage
    {
        public int CreativeId { get; set; }
        public Guid InitiatingUserId { get; set; }
        public int BuyerAccountId { get; set; }
    }
}
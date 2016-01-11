namespace Brandscreen.Core.MiniBuss.Messages
{
    public class CreativeRejectionReceivedEvent : IMessage
    {
        public int CreativeId { get; set; }
        public int PartnerId { get; set; }
        public int[] ReasonIds { get; set; }
    }
}
namespace Brandscreen.Entities
{
    /// <summary>
    /// Partner seat targeting data (BuyerAccountPartnerSeatView and AdGroupTargetingView)
    /// </summary>
    public class AdGroupPartnerSeat
    {
        public int PartnerId { get; set; }
        public string BuyerId { get; set; }
        public int TargetingActionId { get; set; }
    }
}
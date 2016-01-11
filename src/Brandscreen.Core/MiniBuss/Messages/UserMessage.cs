using System;

namespace Brandscreen.Core.MiniBuss.Messages
{
    public class UserMessage : CrudMessage
    {
        public int BuyerAccountId { get; set; }
        public Guid BuyerAccountUuid { get; set; }
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
        public bool IsNewUser { get; set; } 
    }
}
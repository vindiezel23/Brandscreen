using Brandscreen.Entities;

namespace Brandscreen.Core.Services.Accounts
{
    public static class AccountExtensions
    {
        public static AccountStatusEnum GetStatus(this BuyerAccount buyerAccount)
        {
            if (!buyerAccount.UtcStatusChangedDateTime.HasValue)
            {
                return AccountStatusEnum.Pending;
            }

            AccountStatusEnum status;
            if (buyerAccount.IsApproved)
            {
                status = buyerAccount.IsActive ? AccountStatusEnum.Activated : AccountStatusEnum.Suspended;
            }
            else
            {
                status = AccountStatusEnum.Rejected;
            }
            return status;
        }
    }
}
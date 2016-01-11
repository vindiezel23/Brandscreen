using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Users;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Services;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Accounts
{
    public interface IAccountService : IDependency
    {
        Task<BuyerAccount> GetAccount(int id);
        Task<BuyerAccount> GetAccount(Guid id);
        IQueryable<BuyerAccount> GetAccounts();
        IQueryable<BuyerAccount> GetAccounts(AccountQueryOptions options);

        Task CreateAccount(BuyerAccount buyerAccount, User owner);
        Task UpdateAccount(BuyerAccount buyerAccount);
        Task DeleteAccount(Guid id);

        Task ChangeAccountStatus(Guid id, AccountStatusEnum newStatus);
        Task<AccountStatusEnum> GetAccountStatus(Guid id);
    }

    public class AccountService : IAccountService
    {
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IRepositoryAsync<BuyerAccount> _buyerAccountRepositoryAsync;
        private readonly IClock _clock;

        public AccountService(IBrandscreenContext brandscreenContext, IRepositoryAsync<BuyerAccount> buyerAccountRepositoryAsync, IClock clock)
        {
            _brandscreenContext = brandscreenContext;
            _buyerAccountRepositoryAsync = buyerAccountRepositoryAsync;
            _clock = clock;
        }

        public async Task<BuyerAccount> GetAccount(int id)
        {
            var account = await _buyerAccountRepositoryAsync.FindAsync(id);
            return account?.IsDeleted == false ? account : null;
        }

        public Task<BuyerAccount> GetAccount(Guid id)
        {
            return _buyerAccountRepositoryAsync.Queryable()
                .Include(x => x.Country)
                .Include(x => x.Currency)
                .Include(x => x.Language)
                .Include(x => x.TimeZone)
                .FirstOrDefaultAsync(x => !x.IsDeleted && x.BuyerAccountUuid == id);
        }

        public IQueryable<BuyerAccount> GetAccounts()
        {
            var souce = _buyerAccountRepositoryAsync.Queryable()
                .Include(x => x.Country)
                .Include(x => x.Currency)
                .Include(x => x.Language)
                .Include(x => x.TimeZone)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CompanyName);
            return souce;
        }

        public IQueryable<BuyerAccount> GetAccounts(AccountQueryOptions options)
        {
            var source = GetAccounts();

            if (options.UserId.HasValue)
            {
                source = source.Where(x => x.UserBuyerRoles.Any(y => y.UserId == options.UserId.Value));
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                source = source.Where(x => x.CompanyName.Contains(options.Text));
            }

            return source;
        }

        public async Task CreateAccount(BuyerAccount buyerAccount, User owner)
        {
            buyerAccount.BuyerAccountUuid = IdentityValue.GenerateNewId();
            buyerAccount.CommercialContactUserId = owner.UserId;
            buyerAccount.TermsConditionsAgreedDate = _clock.UtcNow;
            buyerAccount.UtcCreatedDateTime = _clock.UtcNow;
            buyerAccount.UserBuyerRoles.Add(new UserBuyerRole
            {
                ObjectState = ObjectState.Added,
                UserId = owner.UserId,
                BuyerAccountId = buyerAccount.BuyerAccountId,
                RoleName = StandardRole.Administrator,
                IsAccepted = true,
                CostView = (int) CostViewEnum.ClientCost
            });
            _buyerAccountRepositoryAsync.Insert(buyerAccount);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task UpdateAccount(BuyerAccount buyerAccount)
        {
            buyerAccount.UtcModifiedDateTime = _clock.UtcNow;
            _buyerAccountRepositoryAsync.Update(buyerAccount);
            await _brandscreenContext.SaveChangesAsync();
        }

        public async Task DeleteAccount(Guid id)
        {
            var buyerAccount = await GetAccount(id);
            buyerAccount.IsDeleted = true;
            await UpdateAccount(buyerAccount);
        }

        public async Task ChangeAccountStatus(Guid id, AccountStatusEnum newStatus)
        {
            if (newStatus == AccountStatusEnum.Pending) throw new BrandscreenException("cannot change to pending status");

            var account = await GetAccount(id);
            switch (newStatus)
            {
                case AccountStatusEnum.Rejected:
                    if (account.UtcStatusChangedDateTime.HasValue)
                    {
                        throw new BrandscreenException("cannot change to rejected status as it has been activated or rejected");
                    }
                    account.IsApproved = false;
                    account.IsActive = false;
                    account.UtcStatusChangedDateTime = _clock.UtcNow;
                    _buyerAccountRepositoryAsync.Update(account);
                    break;
                case AccountStatusEnum.Activated:
                    account.IsApproved = true;
                    account.IsActive = true;
                    account.UtcStatusChangedDateTime = _clock.UtcNow;
                    _buyerAccountRepositoryAsync.Update(account);
                    break;
                case AccountStatusEnum.Suspended:
                    if (!account.UtcStatusChangedDateTime.HasValue)
                    {
                        throw new BrandscreenException("cannot chagne to suspended status only activated or rejected status is allowed");
                    }
                    account.IsActive = false;
                    account.UtcStatusChangedDateTime = _clock.UtcNow;
                    _buyerAccountRepositoryAsync.Update(account);
                    break;
            }

            if (account.ObjectState == ObjectState.Modified)
            {
                // new status has been accepted
                await _brandscreenContext.SaveChangesAsync();
            }
            else
            {
                throw new BrandscreenException($"not support {newStatus} status");
            }
        }

        public async Task<AccountStatusEnum> GetAccountStatus(Guid id)
        {
            var account = await GetAccount(id);
            return account.GetStatus();
        }
    }
}
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Brandscreen.Core.MiniBuss;
using Brandscreen.Core.MiniBuss.Messages;
using Brandscreen.Core.Security;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.Entities;
using Brandscreen.Framework;
using LinqKit;
using Microsoft.AspNet.Identity;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Users
{
    public interface IUserService : IDependency
    {
        Task<User> GetUser(Guid id);
        IQueryable<User> GetUsers();
        IQueryable<User> GetUsers(UserQueryOptions options);
        IQueryable<UserBuyerRole> GetUserBuyerRoles(Guid id);

        Task CreateUser(User user);
        Task UpdateUser(User user);

        /// <summary>
        /// Creates brand new user and buyer account.
        /// </summary>
        Task<IdentityResult> RegisterUser(User user, string password, BuyerAccount buyerAccount);

        /// <summary>
        /// Gives an user access to a buyer account by specifying role: AgencyAdministrator or AgencyUser. Creates user if user doesn't exist.
        /// </summary>
        Task AssignUserToBuyerAccount(Guid buyerAccountUuid, string userEmail, string userBuyerRole, CostViewEnum costView, Guid operatorUserId);

        /// <summary>
        /// Removes user's accesst to a buyer account
        /// </summary>
        Task RemoveUserFromBuyerAccount(Guid buyerAccountUuid, Guid userId);
    }

    public class UserService : IUserService
    {
        private readonly IServiceBus _serviceBus;
        private readonly IAccountService _accountService;
        private readonly IBrandscreenContext _brandscreenContext;
        private readonly IRepositoryAsync<User> _userRepositoryAsync;
        private readonly IRepositoryAsync<UserBuyerRole> _userBuyerRoleRepositoryAsync;
        private readonly ApplicationUserManager _applicationUserManager;

        public UserService(IServiceBus serviceBus,
            IAccountService accountService,
            IBrandscreenContext brandscreenContext,
            IRepositoryAsync<User> userRepositoryAsync,
            IRepositoryAsync<UserBuyerRole> userBuyerRoleRepositoryAsync,
            ApplicationUserManager applicationUserManager)
        {
            _serviceBus = serviceBus;
            _accountService = accountService;
            _brandscreenContext = brandscreenContext;
            _userRepositoryAsync = userRepositoryAsync;
            _userBuyerRoleRepositoryAsync = userBuyerRoleRepositoryAsync;
            _applicationUserManager = applicationUserManager;
        }

        public Task<User> GetUser(Guid id)
        {
            return _userRepositoryAsync.FindAsync(id);
        }

        public IQueryable<User> GetUsers()
        {
            return _userRepositoryAsync.Queryable()
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ThenBy(x => x.UserName);
        }

        public IQueryable<User> GetUsers(UserQueryOptions options)
        {
            var users = GetUsers().AsExpandable();

            if (options.BuyerAccountIds.Count > 0)
            {
                users = users.Where(x => x.UserBuyerRoles.Any(userBuyerRole => options.BuyerAccountIds.Contains(userBuyerRole.BuyerAccount.BuyerAccountId)));
            }

            if (!string.IsNullOrEmpty(options.Email))
            {
                users = users.Where(x => x.Email.Contains(options.Email));
            }

            if (!string.IsNullOrEmpty(options.Text))
            {
                var predicate = PredicateBuilder.False<User>();
                if (options.Text.Contains(' '))
                {
                    predicate = predicate.Or(x => (x.FirstName + " " + x.LastName).Contains(options.Text));
                    predicate = predicate.Or(x => (x.LastName + " " + x.FirstName).Contains(options.Text));
                }
                else
                {
                    predicate = predicate.Or(x => (x.FirstName + x.LastName).Contains(options.Text));
                    predicate = predicate.Or(x => (x.LastName + x.FirstName).Contains(options.Text));
                }
                users = users.Where(predicate);
            }

            return users;
        }

        public IQueryable<UserBuyerRole> GetUserBuyerRoles(Guid id)
        {
            return _userBuyerRoleRepositoryAsync.Queryable()
                .Where(x => x.UserId == id && !x.BuyerAccount.IsDeleted && x.BuyerAccount.IsApproved && x.BuyerAccount.IsActive)
                .OrderBy(x => x.RoleName);
        }

        public Task CreateUser(User user)
        {
            _userRepositoryAsync.Insert(user);
            return _brandscreenContext.SaveChangesAsync();
        }

        public Task UpdateUser(User user)
        {
            _userRepositoryAsync.Update(user);
            return _brandscreenContext.SaveChangesAsync();
        }

        public async Task<IdentityResult> RegisterUser(User user, string password, BuyerAccount buyerAccount)
        {
            // try to create user in ASP.NET IDENTITY
            var applicationUser = new ApplicationUser
            {
                ApplicationId = _applicationUserManager.GetApplicationId(),
                Email = user.Email,
                UserName = user.Email,
                IsApproved = true,
                EmailConfirmed = true, // set to confirmed
            };
            var result = await _applicationUserManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded) return result;

            // create user
            user.UserId = Guid.Parse(applicationUser.Id);
            user.TimeSpanId = (int) TimeSpanEnum.LastMonth;
            user.TermsAndConditionsAgreedDate = DateTime.UtcNow;
            _userRepositoryAsync.Insert(user);

            // create buyer account for the user: context save changes will be called
            await _accountService.CreateAccount(buyerAccount, user);

            // msmq: new user creation email
            _serviceBus.Send(new UserMessage
            {
                Action = CrudAction.Created,
                BuyerAccountId = buyerAccount.BuyerAccountId,
                UserId = user.UserId,
                NewPassword = password,
                InitiatingUserId = user.UserId,
                BuyerAccountUuid = buyerAccount.BuyerAccountUuid
            }, noThrowServiceNotAvailableException: true);

            return result;
        }

        public async Task AssignUserToBuyerAccount(Guid buyerAccountUuid, string userEmail, string userBuyerRole, CostViewEnum costView, Guid operatorUserId)
        {
            var sendConfirmEmail = false;
            var isNewUser = false;

            var buyerAccount = await _accountService.GetAccount(buyerAccountUuid);
            var user = await _userRepositoryAsync.Queryable().Include(x => x.UserBuyerRoles).FirstOrDefaultAsync(x => x.UserName == userEmail);

            // create user if user doesn't exist
            if (user == null)
            {
                // try to create user in ASP.NET IDENTITY
                var applicationUser = await _applicationUserManager.FindByNameAsync(userEmail);
                if (applicationUser == null)
                {
                    var password = RandomPassword.Generate(8);
                    applicationUser = new ApplicationUser
                    {
                        ApplicationId = _applicationUserManager.GetApplicationId(),
                        Email = userEmail,
                        UserName = userEmail,
                        IsApproved = false // no approval
                    };
                    var result = await _applicationUserManager.CreateAsync(applicationUser, password);
                    if (!result.Succeeded)
                    {
                        throw new BrandscreenException(string.Join("\n", result.Errors.ToArray()));
                    }
                    isNewUser = true;
                }

                // create new user
                user = new User
                {
                    UserId = Guid.Parse(applicationUser.Id),
                    UserName = userEmail,
                    Email = userEmail,
                    TimeSpanId = (int) TimeSpanEnum.LastMonth,
                    LanguageId = buyerAccount.LanguageId
                };
                await CreateUser(user);
                sendConfirmEmail = true; // send email
            }

            // check role
            var userRoles = user.UserBuyerRoles.FirstOrDefault(o => o.BuyerAccountId == buyerAccount.BuyerAccountId);
            if (userRoles != null)
            {
                // the email address is already existing on the account so just update the role based on the passed parameters
                // user cannot change his own role
                if (user.UserId != operatorUserId)
                {
                    userRoles.RoleName = userBuyerRole;
                }
                userRoles.CostView = (int) costView;
            }
            else
            {
                // add new role to the user
                user.UserBuyerRoles.Add(new UserBuyerRole
                {
                    ObjectState = ObjectState.Added,
                    BuyerAccountId = buyerAccount.BuyerAccountId,
                    RoleName = userBuyerRole,
                    UserId = user.UserId,
                    User = user,
                    CostView = (int) costView
                });
                sendConfirmEmail = true; // send email
                isNewUser = true;
            }

            // update user
            await UpdateUser(user);

            // msmq: send email that will allow user to enter firstname, lastname, password, language, mobile no.
            if (sendConfirmEmail)
            {
                _serviceBus.Send(new UserMessage
                {
                    IsNewUser = isNewUser,
                    Action = CrudAction.Created,
                    BuyerAccountId = buyerAccount.BuyerAccountId,
                    BuyerAccountUuid = buyerAccount.BuyerAccountUuid,
                    UserId = user.UserId,
                    InitiatingUserId = operatorUserId
                }, noThrowServiceNotAvailableException: true);
            }
        }

        public Task RemoveUserFromBuyerAccount(Guid buyerAccountUuid, Guid userId)
        {
            var userBuyerRoles = _userBuyerRoleRepositoryAsync.Queryable().Where(x => x.BuyerAccount.BuyerAccountUuid == buyerAccountUuid && x.UserId == userId);
            foreach (var userBuyerRole in userBuyerRoles)
            {
                _userBuyerRoleRepositoryAsync.Delete(userBuyerRole);
            }
            return _brandscreenContext.SaveChangesAsync();
        }
    }
}
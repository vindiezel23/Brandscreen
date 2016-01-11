using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.Indexed;
using Brandscreen.Core.DbAsyncWrapper;
using Brandscreen.Core.Security;
using Brandscreen.Entities;
using Brandscreen.Framework;
using Brandscreen.Framework.Caching;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using Repository.Pattern.Repositories;

namespace Brandscreen.Core.Services.Memberships
{
    public interface IMembershipService : IDependency
    {
        IQueryable<ApplicationUser> GetUsers();
        IQueryable<ApplicationUser> GetUsers(ApplicationUserQueryOptions options);
        Task<ApplicationUser> GetUser(Guid id);
        Task<ApplicationUser> GetUser(string email);
        Task<ApplicationUser> GetUser(string email, string password);
        Task<IList<string>> GetUserRoles(Guid id);
        Task<IList<Claim>> GetUserClaims(Guid id);

        Task<IdentityResult> CreateUser(ApplicationUserCreateOptions options);
        Task<IdentityResult> UpdateUser(ApplicationUserUpdateOptions options);
        Task<IdentityResult> DeleteUser(Guid id);

        Task<ClaimsIdentity> CreateIdentity(Guid id, string authenticationType);

        IQueryable<IdentityRole> GetRoles();
        Task<IdentityRole> GetRole(Guid id);
        Task<IdentityRole> GetRole(string role);

        Task<IdentityResult> CreateRole(string role);
        Task<IdentityResult> DeleteRole(Guid id);

        IQueryable<string> GetClaimTypes();
    }

    public class MembershipService : IMembershipService
    {
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationRoleManager _applicationRoleManager;
        private readonly ICacheManager _cacheManager;
        private readonly IIndex<string, DbContext> _dbContextIndex;
        private readonly ILifetimeScope _scope;

        public MembershipService(ApplicationUserManager applicationUserManager, ApplicationRoleManager applicationRoleManager, ICacheManager cacheManager, IIndex<string, DbContext> dbContextIndex, ILifetimeScope scope)
        {
            _applicationUserManager = applicationUserManager;
            _applicationRoleManager = applicationRoleManager;
            _cacheManager = cacheManager;
            _dbContextIndex = dbContextIndex;
            _scope = scope;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _applicationUserManager.Users.OrderBy(x => x.UserName);
        }

        public IQueryable<ApplicationUser> GetUsers(ApplicationUserQueryOptions options)
        {
            var users = GetUsers();

            if (!string.IsNullOrEmpty(options.Text))
            {
                users = users.Where(x => x.Email.Contains(options.Text));
            }

            return users;
        }

        public Task<ApplicationUser> GetUser(Guid id)
        {
            return _applicationUserManager.FindByIdAsync(id.ToString());
        }

        public Task<ApplicationUser> GetUser(string email)
        {
            return _applicationUserManager.FindByEmailAsync(email);
        }

        public Task<ApplicationUser> GetUser(string email, string password)
        {
            return _applicationUserManager.FindAsync(email, password);
        }

        public Task<IList<string>> GetUserRoles(Guid id)
        {
            return _applicationUserManager.GetRolesAsync(id.ToString());
        }

        public Task<IList<Claim>> GetUserClaims(Guid id)
        {
            return _applicationUserManager.GetClaimsAsync(id.ToString());
        }

        public async Task<IdentityResult> CreateUser(ApplicationUserCreateOptions options)
        {
            using (TransactionWrapper.Create(_dbContextIndex["membership"]))
            {
                // user
                var applicationUser = new ApplicationUser
                {
                    ApplicationId = _applicationUserManager.GetApplicationId(),
                    Email = options.Email,
                    UserName = options.Email,
                    IsApproved = true,
                    EmailConfirmed = true,
                };
                var result = await _applicationUserManager.CreateAsync(applicationUser, options.Password);
                if (!result.Succeeded) return result;

                // reload user
                var user = await _applicationUserManager.FindByEmailAsync(options.Email);

                // roles
                if (options.Roles != null && options.Roles.Count > 0)
                {
                    result = await _applicationUserManager.AddToRolesAsync(user.Id, options.Roles.ToArray());
                    if (!result.Succeeded) return result;
                }

                // claims
                if (options.Claims != null && options.Claims.Count > 0)
                {
                    foreach (var claim in options.Claims)
                    {
                        result = await _applicationUserManager.AddClaimAsync(user.Id, claim);
                        if (!result.Succeeded) return result;
                    }
                }

                return result;
            }
        }

        public async Task<IdentityResult> UpdateUser(ApplicationUserUpdateOptions options)
        {
            using (TransactionWrapper.Create(_dbContextIndex["membership"]))
            {
                var result = IdentityResult.Success;
                var userId = options.UserId.ToString();

                // password
                if (!string.IsNullOrEmpty(options.Password))
                {
                    var resetToken = await _applicationUserManager.GeneratePasswordResetTokenAsync(userId);
                    result = await _applicationUserManager.ResetPasswordAsync(userId, resetToken, options.Password);
                    if (!result.Succeeded) return result;
                }

                // roles
                if (options.Roles != null)
                {
                    // remove
                    var roles = await _applicationUserManager.GetRolesAsync(userId);
                    result = await _applicationUserManager.RemoveFromRolesAsync(userId, roles.Except(options.Roles).ToArray());
                    if (!result.Succeeded) return result;

                    // add
                    result = await _applicationUserManager.AddToRolesAsync(userId, options.Roles.Except(roles).ToArray());
                    if (!result.Succeeded) return result;
                }

                // claims
                if (options.Claims != null)
                {
                    // remove
                    var claims = await _applicationUserManager.GetClaimsAsync(userId);
                    foreach (var claim in claims)
                    {
                        result = await _applicationUserManager.RemoveClaimAsync(userId, claim);
                        if (!result.Succeeded) return result;
                    }

                    // add
                    foreach (var claim in options.Claims)
                    {
                        result = await _applicationUserManager.AddClaimAsync(userId, claim);
                        if (!result.Succeeded) return result;
                    }
                }

                return result;
            }
        }

        public async Task<IdentityResult> DeleteUser(Guid id)
        {
            var userId = id.ToString();

            using (TransactionWrapper.Create(_dbContextIndex["membership"]))
            {
                // roles
                var roles = await _applicationUserManager.GetRolesAsync(userId);
                var result = await _applicationUserManager.RemoveFromRolesAsync(userId, roles.ToArray());
                if (!result.Succeeded) return result;

                // claims
                var claims = await _applicationUserManager.GetClaimsAsync(userId);
                foreach (var claim in claims)
                {
                    result = await _applicationUserManager.RemoveClaimAsync(userId, claim);
                    if (!result.Succeeded) return result;
                }

                // user
                var user = await GetUser(id);
                result = await _applicationUserManager.DeleteAsync(user);
                if (!result.Succeeded) return result;

                return result;
            }
        }

        public async Task<ClaimsIdentity> CreateIdentity(Guid id, string authenticationType)
        {
            var applicationUser = await _applicationUserManager.FindByIdAsync(id.ToString());
            var claimsIdentity = await _applicationUserManager.CreateIdentityAsync(applicationUser, authenticationType);

            // user
            var userRepo = _scope.Resolve<IRepositoryAsync<User>>();
            var user = (await userRepo.Query(x => x.UserId == id)
                .Include(x => x.UserBuyerRoles.Select(role => role.BuyerAccount))
                .SelectAsync()
                .ConfigureAwait(false))
                .SingleOrDefault();
            if (user != null)
            {
                // user roles
                if (user.IsSuperAdministrator)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, StandardRole.SuperAdministrator, ClaimValueTypes.String));
                }
                if (user.IsSystemAdministrator)
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, StandardRole.SystemAdministrator, ClaimValueTypes.String));
                }

                // user buyer roles
                var buyerRoles = user.UserBuyerRoles
                    .Where(x => !x.BuyerAccount.IsDeleted && x.BuyerAccount.IsApproved && x.BuyerAccount.IsActive)
                    .Select(x => new BuyerRole {BuyerId = x.BuyerAccountId, BuyerUuid = x.BuyerAccount.BuyerAccountUuid, RoleName = x.RoleName}).ToList();
                var buyerRolesJsonValue = JsonConvert.SerializeObject(buyerRoles);
                claimsIdentity.AddClaim(new Claim(ClaimTypes.UserData, buyerRolesJsonValue, ClaimValueTypes.String));
            }

            return claimsIdentity;
        }

        public IQueryable<IdentityRole> GetRoles()
        {
            return _applicationRoleManager.Roles.OrderBy(x => x.Name);
        }

        public Task<IdentityRole> GetRole(Guid id)
        {
            return _applicationRoleManager.FindByIdAsync(id.ToString());
        }

        public Task<IdentityRole> GetRole(string role)
        {
            return _applicationRoleManager.FindByNameAsync(role);
        }

        public async Task<IdentityResult> CreateRole(string role)
        {
            var exists = await _applicationRoleManager.RoleExistsAsync(role);
            if (exists) return new IdentityResult($"The {role} exists already.");
            return await _applicationRoleManager.CreateAsync(new IdentityRole(role));
        }

        public async Task<IdentityResult> DeleteRole(Guid id)
        {
            var identityRole = await _applicationRoleManager.FindByIdAsync(id.ToString());
            if (identityRole.Users.Count > 0) return new IdentityResult($"The {identityRole.Name} is in using.");
            return await _applicationRoleManager.DeleteAsync(identityRole);
        }

        public IQueryable<string> GetClaimTypes()
        {
            var source = _cacheManager.Get(typeof (StandardClaimType), context =>
            {
                var fields = typeof (StandardClaimType).GetFields();
                return fields.Select(fieldInfo => fieldInfo.GetRawConstantValue().ToString()).ToList();
            });
            return source.ToAsyncEnumerable();
        }
    }
}
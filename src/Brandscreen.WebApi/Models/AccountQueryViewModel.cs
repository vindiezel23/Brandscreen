using System;
using AutoMapper;
using Brandscreen.Core.Services.Accounts;
using Brandscreen.WebApi.Paginations;

namespace Brandscreen.WebApi.Models
{
    public class AccountQueryViewModel : Pagination
    {
        /// <summary>
        /// Super/System admins can set to anyone, otherwise leave null or set to the request user id.
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Filter by company name.
        /// </summary>
        public string Text { get; set; }
    }

    public class AccountQueryViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<AccountQueryViewModel, AccountQueryOptions>();
        }
    }
}
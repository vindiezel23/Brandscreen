using System.Security.Claims;
using AutoMapper;

namespace Brandscreen.WebApi.Models
{
    public class ApplicationUserClaimViewModel
    {
        /// <summary>
        /// Gets the issuer of the claim.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets the claim type of the claim.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets the value of the claim.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets the value type of the claim.
        /// </summary>
        public string ValueType { get; set; }
    }

    public class ApplicationUserClaimViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<Claim, ApplicationUserClaimViewModel>();
        }
    }
}
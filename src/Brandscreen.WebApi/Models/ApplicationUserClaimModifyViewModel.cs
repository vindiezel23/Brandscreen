using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using AutoMapper;

namespace Brandscreen.WebApi.Models
{
    public class ApplicationUserClaimModifyViewModel
    {
        /// <summary>
        /// Sets the issuer of the claim.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Sets the claim type of the claim.
        /// </summary>
        [Required]
        public string Type { get; set; }

        /// <summary>
        /// Sets the value of the claim.
        /// </summary>
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// Sets the value type of the claim.
        /// </summary>
        public string ValueType { get; set; }
    }

    public class ApplicationUserClaimModifyViewModelMapper : Profile
    {
        protected override void Configure()
        {
            CreateMap<ApplicationUserClaimModifyViewModel, Claim>()
                .ConstructUsing(model =>
                {
                    var retVal = new Claim(model.Type, model.Value, model.ValueType, model.Issuer);
                    return retVal;
                });
        }
    }
}
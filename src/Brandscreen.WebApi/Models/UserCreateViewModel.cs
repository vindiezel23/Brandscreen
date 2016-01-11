using System;
using System.ComponentModel.DataAnnotations;
using Brandscreen.Core.Services.Users;

namespace Brandscreen.WebApi.Models
{
    public class UserCreateViewModel
    {
        [Required]
        public Guid? BuyerAccountUuid { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// AgencyAdministrator, or AgencyUser
        /// </summary>
        [Required]
        [RegularExpression("^(?:AgencyAdministrator|AgencyUser)$", ErrorMessage = "The field Role is invalid.")]
        public string Role { get; set; }

        /// <summary>
        /// AgencyCost, or ClientCost
        /// </summary>
        [Required]
        [EnumDataType(typeof (CostViewEnum))]
        public string CostView { get; set; }
    }
}
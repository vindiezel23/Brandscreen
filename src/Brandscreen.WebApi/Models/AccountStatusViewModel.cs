using System.ComponentModel.DataAnnotations;
using Brandscreen.Core.Services.Accounts;

namespace Brandscreen.WebApi.Models
{
    public class AccountStatusViewModel
    {
        /// <summary>
        /// Rejected, Activated, or Suspended
        /// </summary>
        [Required]
        [EnumDataType(typeof (AccountStatusEnum))]
        public string Status { get; set; }
    }
}
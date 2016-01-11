using System;
using System.ComponentModel.DataAnnotations;

namespace Brandscreen.WebApi.Models
{
    public class UserDeleteViewModel
    {
        [Required]
        public Guid? BuyerAccountUuid { get; set; } 
    }
}
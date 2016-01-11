using System.ComponentModel.DataAnnotations;

namespace Brandscreen.WebApi.Models
{
    public class ApplicationRoleCreateViewModel
    {
        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }
    }
}
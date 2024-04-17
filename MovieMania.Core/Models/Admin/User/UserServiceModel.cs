using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MovieMania.Core.Models.Admin.User
{
    public class UserServiceModel
    {
        public string Email { get; set; } = string.Empty;
        
        [Display(Name = "Full name")]
        public string FullName { get; set; } = string.Empty;

    }
}

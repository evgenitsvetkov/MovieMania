using System.ComponentModel.DataAnnotations;

namespace MovieMania.Core.Models.Admin.User
{
    public class UserServiceModel
    {
        public string Email { get; set; } = null!;
        
        [Display(Name = "Full name")]
        public string FullName { get; set; } = null!;

    }
}

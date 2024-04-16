using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.CustomUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Infrastructure.Data.Models.Carts
{
    [Comment("User's shopping cart")]
    public class Cart
    {
        [Key]
        [Comment("Shopping cart's identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User's identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;

        public IEnumerable<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    }
}

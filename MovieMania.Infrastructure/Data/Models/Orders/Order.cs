using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.CustomUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MovieMania.Infrastructure.Constants.DataConstants;


namespace MovieMania.Infrastructure.Data.Models.Orders
{
    [Comment("User's order")]
    public class Order
    {
        [Key]
        [Comment("Order's identifier")]
        public int OrderId { get; set; }

        [Required]
        [Comment("User's identifier")]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [Comment("User's last name")]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(UserAddressMaxLength)]
        [Comment("User's address")]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(UserCityMaxLength)]
        [Comment("User's city")]
        public string City { get; set; } = null!;

        [MaxLength(StateMaxLength)]
        [Comment("User's state")]
        public string State { get; set; } = string.Empty;

        [MaxLength(PostalCodeMaxLength)]
        [Comment("User's postal code")]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(UserCountryMaxLength)]
        [Comment("User's country")]
        public string Country { get; set; } = null!;

        [Required]
        [MaxLength(UserPhoneMaxLength)]
        [Comment("User's phone")]
        public string Phone { get; set; } = null!;

        [Required]
        [MaxLength(UserEmailMaxLength)]
        [Comment("User's email")]
        public string Email { get; set; } = null!;

        [Required]
        [Comment("Order's total amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [Comment("The date of order")]
        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
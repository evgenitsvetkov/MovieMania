using Microsoft.EntityFrameworkCore;
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
        public int Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        [Comment("User's username")]
        public string Username { get; set; } = null!;

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

        [Comment("User's state")]
        public string State { get; set; } = string.Empty;

        [Comment("User's postal code")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
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
        [Comment("Order's total price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; } 

        [Comment("The date of order")]
        public DateTime OrderDate { get; set; }
                     
        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();   

    }
}

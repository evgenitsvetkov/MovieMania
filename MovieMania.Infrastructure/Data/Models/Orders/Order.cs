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
        [Comment("Order identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(UsernameMaxLength)]
        [Comment("Username of user")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(FirstNameMaxLength)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [Comment("User's last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("User's address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("User's city")]
        public string City { get; set; } = string.Empty;

        [MaxLength(PostalCodeMaxLength)]
        [Comment("User's postal code")]
        public string PostalCode { get; set; } = string.Empty;

        [MaxLength(CountryMaxLength)]
        [Comment("User's country")]
        public string Country { get; set; } = string.Empty;

        [Required]
        [MaxLength(PhoneMaxLength)]
        [Comment("User's phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MaxLength(EmailMaxLength)]
        [Comment("User's email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Comment("Total price of order")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Comment("The date of order")]
        public DateTime OrderDate { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();   

    }
}

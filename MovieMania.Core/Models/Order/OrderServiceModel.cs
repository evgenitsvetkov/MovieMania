using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MovieMania.Infrastructure.Constants.DataConstants;
using static MovieMania.Core.Constants.MessageConstants;
using MovieMania.Core.Models.Cart;
using MovieMania.Infrastructure.Data.Models.Orders;

namespace MovieMania.Core.Models.Order
{
    public class OrderServiceModel
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserFirstNameMaxLength,
          MinimumLength = UserFirstNameMinLength,
          ErrorMessage = LengthMessage)]
        [Comment("User's first name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserLastNameMaxLength,
            MinimumLength = UserLastNameMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's last name")]
        public string LastName { get; set; } = null!;

        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserAddressMaxLength,
            MinimumLength = UserAddressMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's address")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserCityMaxLength,
            MinimumLength = UserCityMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's city")]
        public string City { get; set; } = null!;

        [StringLength(StateMaxLength,
            MinimumLength = StateMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's state")]
        public string State { get; set; } = string.Empty;

        [StringLength(PostalCodeMaxLength,
            MinimumLength = PostalCodeMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's postal code")]
        public string PostalCode { get; set; } = string.Empty;

        [StringLength(UserCountryMaxLength,
            MinimumLength = UserCountryMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's country")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserPhoneMaxLength,
            MinimumLength = UserPhoneMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's phone")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserEmailMaxLength,
            MinimumLength = UserEmailMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's email")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Comment("Order's total amount")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public IEnumerable<OrderDetailServiceModel> OrderDetails { get; set; } = new List<OrderDetailServiceModel>();
    }
}

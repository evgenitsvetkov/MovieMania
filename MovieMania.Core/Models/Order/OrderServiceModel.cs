using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Core.Models.Order
{
    public class OrderServiceModel
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserFirstNameMaxLength,
          MinimumLength = UserFirstNameMinLength,
          ErrorMessage = LengthMessage)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserLastNameMaxLength,
            MinimumLength = UserLastNameMinLength,
            ErrorMessage = LengthMessage)]
        public string LastName { get; set; } = null!;

        public string UserId { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserAddressMaxLength,
            MinimumLength = UserAddressMinLength,
            ErrorMessage = LengthMessage)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserCityMaxLength,
            MinimumLength = UserCityMinLength,
            ErrorMessage = LengthMessage)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(StateMaxLength,
            MinimumLength = StateMinLength,
            ErrorMessage = LengthMessage)]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PostalCodeMaxLength,
            MinimumLength = PostalCodeMinLength,
            ErrorMessage = LengthMessage)]
        public string PostalCode { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserCountryMaxLength,
            MinimumLength = UserCountryMinLength,
            ErrorMessage = LengthMessage)]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserPhoneMaxLength,
            MinimumLength = UserPhoneMinLength,
            ErrorMessage = LengthMessage)]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserEmailMaxLength,
            MinimumLength = UserEmailMinLength,
            ErrorMessage = LengthMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public IEnumerable<OrderDetailServiceModel> OrderDetails { get; set; } = new List<OrderDetailServiceModel>();
    }
}

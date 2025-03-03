using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Core.Models.Order
{
    public class OrderFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserFirstNameMaxLength,
            MinimumLength = UserFirstNameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserLastNameMaxLength,
            MinimumLength = UserLastNameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserAddressMaxLength,
            MinimumLength = UserAddressMinLength,
            ErrorMessage = LengthMessage)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserCityMaxLength,
            MinimumLength = UserCityMinLength,
            ErrorMessage = LengthMessage)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(StateMaxLength,
            MinimumLength = StateMinLength,
            ErrorMessage = LengthMessage)]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PostalCodeMaxLength,
            MinimumLength = PostalCodeMinLength,
            ErrorMessage =LengthMessage)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserCountryMaxLength,
            MinimumLength = UserCountryMinLength,
            ErrorMessage = LengthMessage)]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserPhoneMaxLength, 
            MinimumLength = UserPhoneMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserEmailMaxLength,
            MinimumLength = UserEmailMinLength,
            ErrorMessage = LengthMessage)]
        public string Email { get; set; } = string.Empty;
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MovieMania.Infrastructure.Constants.DataConstants;
using static MovieMania.Core.Constants.MessageConstants;

namespace MovieMania.Core.Models.Order
{
    public class OrderFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserFirstNameMaxLength,
            MinimumLength = UserFirstNameMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserLastNameMaxLength,
            MinimumLength = UserLastNameMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's last name")]
        [Display(Name = "Last Name")]
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
            ErrorMessage =LengthMessage)]
        [Comment("User's postal code")]
        [Display(Name = "Postal Code")]
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
        [Display(Name = "Phone number")]
        public string Phone { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(UserEmailMaxLength,
            MinimumLength = UserEmailMinLength,
            ErrorMessage = LengthMessage)]
        [Comment("User's email")]
        public string Email { get; set; } = null!;
    }
}

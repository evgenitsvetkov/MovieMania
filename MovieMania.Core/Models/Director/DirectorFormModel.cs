using System.ComponentModel.DataAnnotations;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Core.Models.Director
{
    public class DirectorFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(BioMaxLength,
            MinimumLength = BioMinLength,
            ErrorMessage = LengthMessage)]
        public string Bio { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;
    }
}

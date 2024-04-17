using System.ComponentModel.DataAnnotations;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Core.Models.Actor
{
    public class ActorServiceModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(NameMaxLength,
            MinimumLength = NameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Full name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}

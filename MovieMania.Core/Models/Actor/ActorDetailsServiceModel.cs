using System.ComponentModel.DataAnnotations;

namespace MovieMania.Core.Models.Actor
{
    public class ActorDetailsServiceModel : ActorServiceModel
    {
        public string Bio { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}

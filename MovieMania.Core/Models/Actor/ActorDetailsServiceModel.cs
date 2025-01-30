namespace MovieMania.Core.Models.Actor
{
    public class ActorDetailsServiceModel : ActorServiceModel
    {
        public string Bio { get; set; } = null!;

        public DateTime BirthDate { get; set; }
    }
}

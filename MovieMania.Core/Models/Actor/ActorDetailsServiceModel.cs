namespace MovieMania.Core.Models.Actor
{
    public class ActorDetailsServiceModel : ActorServiceModel
    {
        public string Bio { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }
    }
}

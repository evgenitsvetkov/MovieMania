namespace MovieMania.Core.Models.Actor
{
    public class ActorQueryServiceModel
    {
        public int TotalActorsCount { get; set; }

        public IEnumerable<ActorServiceModel> Actors { get; set; } = new List<ActorServiceModel>();
    }
}

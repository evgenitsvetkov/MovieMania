using MovieMania.Core.Models.Actor;
using MovieMania.Infrastructure.Data.Models.Actors;

namespace System.Linq
{
    public static class IQueryableActorExtension
    {
        public static IQueryable<ActorServiceModel> ProjectToActorServiceModel(this IQueryable<Actor> actors)
        {
            return actors
                .Select(m => new ActorServiceModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMania.Infrastructure.Data.Models.Actors;

namespace MovieMania.Infrastructure.Data.SeedDb.Configurations
{
    internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            var data = new SeedData();

            builder.HasData(new Actor[] 
            { 
                data.FirstActor, 
                data.SecondActor, 
                data.ThirdActor, 
                data.FourthActor, 
                data.FifthActor, 
                data.SixthActor, 
                data.SeventhActor, 
                data.EighthActor 
            });
        }
    }
}

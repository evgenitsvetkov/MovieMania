using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMania.Infrastructure.Data.Models.Movies;

namespace MovieMania.Infrastructure.Data.SeedDb.Configurations
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            var data = new SeedData();

            builder.HasData(new Genre[] 
            {
                data.ActionGenre,
                data.AdventureGenre,
                data.ComedyGenre,
                data.DramaGenre,
                data.CrimeGenre,
                data.BiographyGenre,
                data.HistoryGenre,
                data.RomanceGenre
            });
        }
    }
}

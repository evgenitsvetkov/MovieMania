using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMania.Infrastructure.Data.Models.Movies;

namespace MovieMania.Infrastructure.Data.SeedDb.Configurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
               .HasOne(m => m.Genre)
               .WithMany(m => m.Movies)
               .HasForeignKey(m => m.GenreId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.Director)
                .WithMany(m => m.Movies)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Movie[] 
            {
                data.FirstMovie,
                data.SecondMovie,
                data.ThirdMovie,
                data.FourthMovie,
                data.FifthMovie,
                data.SixthMovie,
                data.SeventhMovie,
                data.EighthMovie
            });
        }
    }
}

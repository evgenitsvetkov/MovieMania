using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMania.Infrastructure.Data.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieMania.Infrastructure.Data.SeedDb.Configurations
{
    internal class MovieActorConfiguration : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            var data = new SeedData();

            builder.HasData(new MovieActor[] 
            {
                data.FirstMovieActor,
                data.SecondMovieActor,
                data.ThirdMovieActor,
                data.FourthMovieActor,
                data.FifthMovieActor,
                data.SixthMovieActor,
                data.SeventhMovieActor,
                data.EighthMovieActor,
                data.NinthMovieActor,
                data.TenthMovieActor,
                data.EleventhMovieActor,
                data.TwelfthMovieActor,
                data.ThirteenthMovieActor,
                data.FourteenthMovieActor,
                data.FifteenthMovieActor,
                data.SixteenthMovieActor,
                data.SeventeenthMovieActor,
            });
        }
    }
}

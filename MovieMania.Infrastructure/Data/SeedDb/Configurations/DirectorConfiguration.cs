using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMania.Infrastructure.Data.Models.Directors;

namespace MovieMania.Infrastructure.Data.SeedDb.Configurations
{
    internal class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            var data = new SeedData();

            builder.HasData(new Director[] 
            {
                data.FirstDirector,
                data.SecondDirector,
                data.ThirdDirector,
                data.FourthDirector,
                data.FifthDirector,
                data.SixthDirector,
                data.SeventhDirector
            });
        }
    }
}

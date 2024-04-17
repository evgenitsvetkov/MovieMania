using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieMania.Infrastructure.Data.Models.CustomUser;

namespace MovieMania.Infrastructure.Data.SeedDb.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new ApplicationUser[] 
            { 
                data.AdminUser, 
                data.GuestUser 
            });
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Actors;
using MovieMania.Infrastructure.Data.Models.Mappings;
using MovieMania.Infrastructure.Data.Models.Movies;
using MovieMania.Infrastructure.Data.Models.Orders;
using MovieMania.Infrastructure.Data.Models.Producers;
using MovieMania.Infrastructure.Data.Models.ShoppingCarts;

namespace MovieMania.Infrastructure.Data
{
    public class MovieManiaDbContext : IdentityDbContext
    {
        public MovieManiaDbContext(DbContextOptions<MovieManiaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(m => m.Movies)
                .HasForeignKey(m => m.GenreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Movie>()
                .HasOne(m => m.Producer)
                .WithMany(m => m.Movies)
                .HasForeignKey(m => m.ProducerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Producer> Producer { get; set; }

        public DbSet<MovieActor> MoviesActors { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}

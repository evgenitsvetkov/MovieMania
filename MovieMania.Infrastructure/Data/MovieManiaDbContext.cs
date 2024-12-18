﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Actors;
using MovieMania.Infrastructure.Data.Models.Carts;
using MovieMania.Infrastructure.Data.Models.CustomUser;
using MovieMania.Infrastructure.Data.Models.Directors;
using MovieMania.Infrastructure.Data.Models.Mappings;
using MovieMania.Infrastructure.Data.Models.Movies;
using MovieMania.Infrastructure.Data.Models.Orders;
using MovieMania.Infrastructure.Data.SeedDb.Configurations;

namespace MovieMania.Infrastructure.Data
{
    public class MovieManiaDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool _seedDb;

        public MovieManiaDbContext(DbContextOptions<MovieManiaDbContext> options, bool seed = true)
            : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }

            _seedDb = seed;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            if (_seedDb)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new ActorConfiguration());
                builder.ApplyConfiguration(new DirectorConfiguration());
                builder.ApplyConfiguration(new GenreConfiguration());
                builder.ApplyConfiguration(new MovieConfiguration());
                builder.ApplyConfiguration(new MovieActorConfiguration());
                builder.ApplyConfiguration(new UserClaimsConfiguration());
                builder.ApplyConfiguration(new CartConfiguration());
            }

            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; } = null!;

        public DbSet<Actor> Actors { get; set; } = null!;

        public DbSet<Director> Directors { get; set; } = null!;

        public DbSet<MovieActor> MoviesActors { get; set; } = null!;

        public DbSet<Genre> Genres { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<CartItem> CartItems { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    }
}

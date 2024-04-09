﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieMania.Infrastructure.Data;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    [DbContext(typeof(MovieManiaDbContext))]
    [Migration("20240402193255_ShoppingCartTablesAdded")]
    partial class ShoppingCartTablesAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Actors.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Actor's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Actor's bio");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasComment("Actor's birthdate");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Actor's profile picture url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Actor's name");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasComment("Movie's actor");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Carts.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Shopping cart's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User's identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");

                    b.HasComment("User's shopping cart");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Carts.CartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Cart detail's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasComment("Movie's identifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Quantity of movies in the cart");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int")
                        .HasComment("Shopping cart's identifier");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartDetails");

                    b.HasComment("Detail of user's shopping cart");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Mappings.MovieActor", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasComment("Movie's identifier");

                    b.Property<int>("ActorId")
                        .HasColumnType("int")
                        .HasComment("Actor's identifier");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MoviesActors");

                    b.HasComment("Movie and actor mapping");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Movies.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Genre's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Genre's name");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasComment("Movie's genre");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Movies.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Movie's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Movie's description");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Movie's director");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasComment("Movie's genre identifier");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Movie's image url");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price for single movie");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int")
                        .HasComment("Producer's identifier");

                    b.Property<double>("Rating")
                        .HasColumnType("float")
                        .HasComment("Movie's rating");

                    b.Property<int>("ReleaseDate")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasComment("Movie's release date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Movie's title");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Movies");

                    b.HasComment("Movie to buy");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Orders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Order's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2")
                        .HasComment("The date of order");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int")
                        .HasComment("Order status identifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User's identifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasComment("User's order");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Orders.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Order detail identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MovieId")
                        .HasColumnType("int")
                        .HasComment("Movie's identifier");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasComment("Order's identifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Quantity of ordered movies");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price for single movie");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");

                    b.HasComment("Details of user's orders");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Orders.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Order status identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Order status name");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasComment("Status identifier");

                    b.HasKey("Id");

                    b.ToTable("OrderStatuses");

                    b.HasComment("Status of user's order");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Producers.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Producer's identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("Producer's bio");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasComment("Producer's birthday");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Producer's profile picture url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Producer's name");

                    b.HasKey("Id");

                    b.ToTable("Producer");

                    b.HasComment("Movie's producer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Carts.Cart", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Carts.CartDetail", b =>
                {
                    b.HasOne("MovieMania.Infrastructure.Data.Models.Movies.Movie", "Movie")
                        .WithMany("CartDetails")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieMania.Infrastructure.Data.Models.Carts.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Mappings.MovieActor", b =>
                {
                    b.HasOne("MovieMania.Infrastructure.Data.Models.Actors.Actor", "Actor")
                        .WithMany("MoviesActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieMania.Infrastructure.Data.Models.Movies.Movie", "Movie")
                        .WithMany("MoviesActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Movies.Movie", b =>
                {
                    b.HasOne("MovieMania.Infrastructure.Data.Models.Movies.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MovieMania.Infrastructure.Data.Models.Producers.Producer", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Orders.Order", b =>
                {
                    b.HasOne("MovieMania.Infrastructure.Data.Models.Orders.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Orders.OrderDetail", b =>
                {
                    b.HasOne("MovieMania.Infrastructure.Data.Models.Movies.Movie", "Movie")
                        .WithMany("OrderDetails")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieMania.Infrastructure.Data.Models.Orders.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Actors.Actor", b =>
                {
                    b.Navigation("MoviesActors");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Carts.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Movies.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Movies.Movie", b =>
                {
                    b.Navigation("CartDetails");

                    b.Navigation("MoviesActors");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Orders.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Orders.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MovieMania.Infrastructure.Data.Models.Producers.Producer", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
using Microsoft.EntityFrameworkCore;
using MovieMania.Infrastructure.Data.Models.Mappings;
using MovieMania.Infrastructure.Data.Models.Orders;
using MovieMania.Infrastructure.Data.Models.Producers;
using MovieMania.Infrastructure.Data.Models.ShoppingCarts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Infrastructure.Data.Models.Movies
{
    [Comment("Movie to buy")]
    public class Movie
    {
        [Key]
        [Comment("Movie's identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MovieTitleMaxLength)]
        [Comment("Movie's title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Comment("Movie's genre identifier")]
        public int GenreId { get; set; }
                
        [ForeignKey(nameof(GenreId))]
        [Comment("Movie's genre")]
        public Genre Genre { get; set; } = null!;

        [Required]
        [MaxLength(MovieReleaseDateMaxLength)]
        [Comment("Movie's release date")]
        public int ReleaseDate { get; set; }

        [Required]
        [Comment("Price for single movie")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Movie's director")]
        public string Director { get; set; } = string.Empty;

        [Required]
        [MaxLength(MovieDescriptionMaxLength)]
        [Comment("Movie's description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Comment("Movie's rating")]
        public double Rating { get; set; }

        [Required]
        [Comment("Producer's identifier")]
        public int ProducerId { get; set; }

        [ForeignKey(nameof(ProducerId))]
        [Comment("Movie's producer")]
        public Producer Producer { get; set; } = null!;

        [Required]
        [Comment("Movie's image url")]
        public string ImageURL { get; set; } = string.Empty;

        public IEnumerable<MovieActor> MoviesActors { get; set; } = new List<MovieActor>();
        public IEnumerable<Cart> Carts { get; set; } = new List<Cart>();
        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieMania.Core.Models.Order
{
    public class OrderDetailServiceModel
    {
        public int OrderDetailId { get; set; }

        public int Quantity { get; set; }

        public decimal ItemTotal { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}

namespace MovieMania.Core.Models.Cart
{
    public class CartServiceModel
    {
        public int CartId { get; set; }

        public decimal TotalPrice { get; set; }

        public IEnumerable<CartItemServiceModel> CartItems { get; set; } = new List<CartItemServiceModel>();
    }
}

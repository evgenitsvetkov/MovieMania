namespace MovieMania.Core.Models.Cart
{
    public class CartItemQueryServiceModel
    {
        public decimal TotalPrice { get; set; }

        public IEnumerable<CartItemServiceModel> CartItems { get; set; } = new List<CartItemServiceModel>();
    }
}

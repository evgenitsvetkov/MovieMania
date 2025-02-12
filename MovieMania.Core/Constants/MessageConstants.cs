namespace MovieMania.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string PriceMustBePositiveMessage = "Price must be a positive number and less than {2} leva";

        public const string MovieNotFoundMessage = "Error while adding movie. Movie not found.";

        public const string UserUnauthorizedMessage = "You are not authenticated. Please log in.";

        public const string InvalidInputMessage = "Invalid input data. Please check your input data.";

        public const string CartNotFoundMessage = "Cart not found.";

        public const string CartIsEmptyMessage = "Cart is empty.";

        public const string CartItemNotFoundMessage = "Cart item not found.";

        public const string ClearCartSuccessMessage = "Cart cleared successfully!";

        public const string LoginUrl = "/Identity/Account/Login";

        public const string CartAllItemsUrl = "/Cart/All";

        public const string OrderNotFoundMessage = "Order not found.";

        public const string CheckoutSuccessMessage = "Checkout was successful.";

        public const string UserMessageSuccess = "UserMessageSuccess";

        public const string UserMessageError = "UserMessageError";
    }
}

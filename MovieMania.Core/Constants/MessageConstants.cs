namespace MovieMania.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string PriceMustBePositiveMessage = "Price must be a positive number and less than {2} leva";

        public const string MovieNotFoundMessage = "Error while adding movie. The Movie was not found.";

        public const string UserUnauthorizedMessage = "You are not authenticated. Please log in.";

        public const string InvalidInputMessage = "Invalid input data. Please check your input data.";

        public const string CartNotFoundMessage = "The cart was not found.";

        public const string CartItemNotFoundMessage = "The cart item was not found.";

        public const string LoginUrl = "/Identity/Account/Login";

        public const string ClearCartSuccessMessage = "You have cleared your cart!";

        public const string UserMessageSuccess = "UserMessageSuccess";

        public const string UserMessageError = "UserMessageError";
    }
}

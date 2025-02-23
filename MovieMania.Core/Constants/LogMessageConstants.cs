namespace MovieMania.Core.Constants
{
    public static class LogMessageConstants
    {
        public const string MovieNotFoundLogMessage = "Movie not found with ID: {MovieId}.";

        public const string MovieCreatedLogMessage = "Successfully created movie with ID: {MovieId}.";

        public const string MovieEditedLogMessage = "Successfully edited movie with ID: {MovieId}.";

        public const string MovieDeletedLogMessage = "Successfully deleted movie with ID: {MovieId}.";

        public const string AddGenreNotExistLogMessage = "Attempted to add a movie with a non-existent genre: {GenreId}.";

        public const string AddDirectorNotExistLogMessage = "Attempted to add a movie with a non-existent director: {DirectorId}.";

        public const string EditGenreNotExistLogMessage = "Attempted to edit a movie with a non-existent genre: {GenreId}.";

        public const string EditDirectorNotExistLogMessage = "Attempted to edit a movie with a non-existent director: {DirectorId}.";

        public const string ModelNotValidLogMessage = "Model validation failed. Returning view with validation errors.";

        public const string CartCreatedLogMessage = "Cart successfully created with ID: {CartId}";

        public const string CartAlreadyExistLogMessage = "CartAlreadyExist with ID: {CartId}";

        public const string CartNotExistCreatingLogMessage = "Cart not exist for user {UserId}. Creating new cart...";

        public const string CartNotExistLogMessage = "Cart not exist for user {UserId}.";

        public const string CartClearedLogMessage = "Cart {CartId} cleared successfully for user {UserId}.";

        public const string CartIsEmptyLogMessage = "Cart is empty for User {UserId}.";

        public const string AddingMovieToCartLogMessage = "User {UserId} is adding movie {MovieId} to cart.";

        public const string UnauthorizedAccessRedirectLogMessage = "Unauthorized access attempt to {MethodName}. Redirecting user to login.";

        public const string UnauthorizedAccessLogMessage = "Unauthorized access attempt to {MethodName}.";

        public const string InvalidModelStateLogMessage = "Invalid model state in {MethodName}. Model: {@Model}";

        public const string CartItemCreatedLogMessage = "Cart item created and added to cart {CartId}. Movie: {MovieId}";

        public const string CartItemQuantityIncreasedLogMessage = "Increased quantity of cart item {CartItemId} in cart {CartId}.";

        public const string CartItemQuantityDecreasedLogMessage = "Decreased quantity of cart item {CartItemId} in cart {CartId}.";

        public const string CartItemNotFoundLogMessage = "Cart item {CartItemId} not found in cart {CartId}.";

        public const string CartItemRemovedLogMessage = "Cart item {CartItemId} successfully removed from cart {CartId}.";

        public const string ActorNotFoundLogMessage = "Actor not found with ID: {ActorId}";

        public const string ActorCreatedLogMessage = "Successfully created actor with ID: {ActorId}.";

        public const string ActorEditedLogMessage = "Successfully edited actor with ID: {ActorId}.";

        public const string ActorDeletedLogMessage = "Successfully deleted actor with ID: {ActorId}.";

        public const string DirectorNotFoundLogMessage = "Director not found with ID: {DirectorId}";

        public const string DirectorCreatedLogMessage = "Successfully created director with ID: {DirectorId}.";

        public const string DirectorEditedLogMessage = "Successfully edited director with ID: {DirectorId}.";

        public const string DirectorDeletedLogMessage = "Successfully deleted director with ID: {DirectorId}.";

        public const string OrderCreatedLogMessage = "Order {OrderId} created for User {UserId}.";

        public const string OrderDetailsCreatedLogMessage = "Order Details created for User {UserId} with Order {OrderId}.";

        public const string OrderNotExistLogMessage = "Order not exist for User {UserId}.";

        public const string AdminOrderNotExistLogMessage = "Order not exist with ID: {OrderId}";
    }
}

var CartModule = (function () {
    function updateCartCount() {
        $.ajax({
            url: "/Cart/GetCartItemCount",
            type: "GET",
            success: function (response) {
                if (response.success) {
                    if (response.count > 0) {
                        $("#cartCount").text(response.count);
                    } else {
                        $("#cartCount").text('');
                    }
                } else {
                    console.log(response.message);
                }
            },
            error: function (xhr) {
                if (xhr.status === 401) {
                    console.log('Error:', xhr.status, xhr.statusText, xhr.responseText);
                } else if (xhr.status === 404) {
                    console.log('Error:', xhr.status, xhr.statusText, xhr.responseText);
                } else {
                    console.log('Error:', xhr.status, xhr.statusText, xhr.responseText);
                    console.log("An unexpected error occurred while fetching cart count.");
                }
            }
        });
    }

    function addToCart(movieId, movieTitle) {
        const data = {
            Id: movieId,
        }

        $.ajax({
            url: "/Cart/AddToCart",
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: {
                'RequestVerificationToken': $('input[id="__RequestVerificationToken"]').val()
            },
            success: function (response) {
                if (response.success) {
                    toastr.success(`You have added ${movieTitle} to your cart!`);

                    updateCartCount();
                } else {
                    toastr.error(response.message, 'Add To Cart Error');
                }
            },
            error: function (xhr) {
                if (xhr.status === 401) {
                    var response = JSON.parse(xhr.responseText);
                    window.location.href = "/Identity/Account/Login?ReturnUrl=" + encodeURIComponent(window.location.pathname);

                    toastr.error(response.message, 'Add To Cart Error');
                } else if (xhr.status === 404) {
                    var response = JSON.parse(xhr.responseText);

                    console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
                    toastr.error(response.message, 'Add To Cart Error');
                } else {
                    console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
                    toastr.error('An unexpected error occurred while adding a movie to cart.', 'Add To Cart Error');
                }
            }
        })
    }

    function createCart() {
        $.ajax({
            url: "/Cart/CreateCart",
            type: "POST",
            contentType: 'application/json',
            headers: {
                'RequestVerificationToken': $('input[id="__RequestVerificationToken"]').val()
            },
            success: function (response) {
                if (response.success) {
                    updateCartCount();
                } else {
                    console.log(response.message);
                }
            },
            error: function (xhr) {
                if (xhr.status === 401) {
                    var response = JSON.parse(xhr.responseText);
                    window.location.href = "/Identity/Account/Login?ReturnUrl=" + encodeURIComponent(window.location.pathname);

                    console.error(response.message);
                } else if (xhr.status === 404) {
                    var response = JSON.parse(xhr.responseText);

                    console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
                } else {
                    console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
                }
            }
        })
    }

    function updateQuantity(cartItemId, isIncrease) {
        const data = {
            Id: cartItemId,
            IsIncrease: isIncrease,
        };

        $.ajax({
            url: "/Cart/UpdateQuantity",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            headers: {
                'RequestVerificationToken': $('input[id="__RequestVerificationToken"]').val()
            },
            success: function (response) {
                if (response.success) {

                    $('.quantity-' + data.Id).text(response.newQuantity);
                    $('.itemPrice-' + data.Id).text((response.itemPrice).toFixed(2) + " BGN");
                    $('.cart-total-amount').text("Total Amount: " + response.totalAmount.toFixed(2) + " BGN")

                    updateCartCount();
                } else {
                    toastr.error(response.message, 'Update Quantity Error');
                }
            },
            error: function (xhr) {
                if (xhr.status === 401) {
                    window.location.href = "/Identity/Account/Login?ReturnUrl=" + encodeURIComponent(window.location.pathname);
                } else if (xhr.status === 404) {
                    var response = JSON.parse(xhr.responseText);

                    console.log('Error:', xhr.status, xhr.statusText, xhr.responseText);
                    toastr.error(response.message, 'Update Quantity Error');
                } else {
                    console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
                    toastr.error('An unexpected error occurred while updating quantity.', 'Update Quantity Error');
                }
            }
        });
    }

    function removeItem(cartItemId, movieTitle) {
        const data = {
            Id: cartItemId,
        };

        $.ajax({
            url: "/Cart/RemoveFromCart",
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: {
                'RequestVerificationToken': $('input[id="__RequestVerificationToken"]').val()
            },
            success: function (response) {
                if (response.success) {
                    updateCartCount();

                    $("#cart-item-" + data.Id).fadeOut();
                    $('.cart-total-amount').text("Total Amount: " + response.newCartTotalAmount.toFixed(2) + " BGN");

                    toastr.success(`You have removed ${movieTitle} from your cart!`);

                    if ($('#cart-items').children(':visible').length <= 1) {
                        $('#cart-count').text('');
                        $('.cart-container').fadeOut();
                        $('main').append('<h2 class="text-center mt-5">Your cart is empty!</h2>');
                    }
                } else {
                    toastr.error(response.message, 'Remove Item From Cart Error');
                }
            },
            error: function (xhr) {
                if (xhr.status === 401) {
                    window.location.href = "/Identity/Account/Login?ReturnUrl=" + encodeURIComponent(window.location.pathname);
                } else if (xhr.status === 404) {
                    var response = JSON.parse(xhr.responseText);
                    console.log(xhr.responseText);
                    console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
                    toastr.error(response.message, 'Remove Item From Cart Error');
                } else {
                    console.error('Error:', xhr.status, xhr.statusText, xhr.responseText);
                    toastr.error('An unexpected error occurred while removing an item from cart.', 'Remove Item From Cart Error');
                }
            }
        });
    }

    function updateButtons(input) {
        let quantity = parseInt($(input).val());
        let min = parseInt($(input).attr("min"));
        let max = parseInt($(input).attr("max"));

        let minusBtn = $(input).siblings(".decrease-qty");
        let plusBtn = $(input).siblings(".increase-qty");

        minusBtn.prop("disabled", quantity <= min);
        plusBtn.prop("disabled", quantity >= max);
    }

    return {
        updateCartCount,
        addToCart,
        createCart,
        updateQuantity,
        removeItem,
        updateButtons
    };
})();
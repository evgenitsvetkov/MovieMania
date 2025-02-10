$(document).ready(function () {
    getCartCount();

    function getCartCount() {
        $.ajax({
            url: "/Cart/GetCartItemCount",
            type: "GET",
            success: function (response) {
                if (response.success) {
                    if (response.count > 0) {
                        $("#cartCount").text(response.count);
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
});
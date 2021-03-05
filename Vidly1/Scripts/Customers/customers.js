$(document).ready(function () {
    $(".js-delete").click(function () {
        var button = $(this);
        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                $.ajax({
                    url: "api/customers/" + button.attr("data-customer-id"),
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                    }
                })
            }
        });
    })
})
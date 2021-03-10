$(document).ready(function () {

    var vm =
    {
        movieIds: []
    };

    var customers = new Bloodhound({ //Bloodhound is an engine of typeahead
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'), //Tokenize name from customers
        queryTokenizer: Bloodhound.tokenizers.whitespace, //Tranform query in tokens
        remote: {
            url: '/api/customers?query=%QUERY', // the url from API to query
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead({
        minLength: 3, // min char to show querys
        highlight: true //The values that match with the query will be bold
    }, {
        name: 'customers',
        display: 'name',
        source: customers
    }).on("typeahead:select", function (e, customer) {
        vm.customerId = customer.id;
    });

    var movie = new Bloodhound({ //Bloodhound is an engine of typeahead
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'), //Tokenize name from customers
        queryTokenizer: Bloodhound.tokenizers.whitespace, //Tranform query in tokens
        remote: {
            url: '/api/movies?query=%QUERY', // the url from API to query
            wildcard: '%QUERY'
        }
    });

    $('#movies').typeahead({
        minLength: 2, // min char to show querys
        highlight: true //The values that match with the query will be bold
    }, {
        name: 'movies',
        display: 'name',
        source: movie
    }).on("typeahead:select", function (e, movie) {
        $("#movie").append("<li class='list-group-item'>" + movie.name + "</li>");

        $("#movie").typeahead("val", "");

        vm.movieIds.push(movie.id);
    });

    $.validator.addMethod("atLeastOneMovie", function () {
        return vm.movieIds.length > 0;
    }, "please select at least one movie");


    $.validator.addMethod("validCustomer", function () {
        return vm.customerId && vm.customerId !== 0;
    }, "Please select a valid customer.");

    $.validator.addMethod("atLeastOneMovie", function () {
        return vm.movieIds.length > 0;
    }, "Please select at least one movie.");

    var validator = $("#newRental").validate({
        submitHandler: function () {
            $.ajax({
                url: "/api/newRentals",
                method: "post",
                data: vm
            })
                .done(function () {
                    toastr.success("Rentals successfully recorded.");
                    $("#customer").typeahead("val", "");
                    $("#movie").typeahead("val", "");
                    $("#movies").empty();
                    vm = { movieIds: [] };
                    validator.resetForm();
                })
                .fail(function () {
                    toastr.error("Something unexpected happened.");
                });
            return false;
        }
    });
})
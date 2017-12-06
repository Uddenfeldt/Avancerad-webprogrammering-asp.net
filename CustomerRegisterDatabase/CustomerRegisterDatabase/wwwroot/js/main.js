


$.ajax({
    url: '/api/Customers/GetCustomers',
    method: 'Get',
})
    .done(function (result) {

        
        $("#customers").text(JSON.stringify(result));

    })

    .fail(function (xhr, status, error) {

    })
//});

$("#addForm button").click(function () {

    $.ajax({
        url: '/api/Customers/',
        method: 'POST',
        data: {
            "FirstName": $("#addForm [name=FirstName]").val(),
        }

    })
        .done(function (result) {

           
            $("#customers").append(result);

        })

        .fail(function (xhr, status, error) {

            alert(`Fail!`)
            console.log("Error", xhr, status, error);

        })
});

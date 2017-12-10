$(document).ready(function () {
    getCustomerList();
});

var Customer = {
    firstName,
    lastName,
    email,
    gender,
    age,
};


function getCustomerList() {
    $.ajax({
        url: '/api/Customers/GetCustomers',
        method: 'Get',
        dataType: 'json',
        success: function (customers) {

            customerListSucces(customers)
        },

        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function customerListSucces(customer) {
    $("#customerTable tbody").remove();
    $.each(customer, function (index, customer) {
        customerAddRow(customer);
    });
}

function customerAddRow(customer) {
    if ($("#customerTable tbody").length == 0) {
        $("#customerTable").append("<tbody></tbody>");
    }

    $("#customerTable tbody").append(
        customerBuildTableRow(customer));
}

function customerBuildTableRow(customer) {
    var newRow = "<tr>" +
        "<td>" + customer.id + "</td>" +
        "<td><input class='input-firstName' type='text' value='" + customer.firstName + "'/></td>" +
        "<td><input class='input-lastName' type='text' value='" + customer.lastName + "' /></td>" +
        "<td><input class='input-email' type='text' value='" + customer.email + "' /></td>" +
        "<td><input class='input-gender' type='text' value='" + customer.gender + "' /></td>" +
        "<td><input class='input-age' type='text' value='" + customer.age + "' /></td>" +
        "<td>" +
        "<button type='button' " +
        "onClick='customerUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + customer.id + "' " +
        "data-firstName='" + customer.firstName + "' " +
        "data-lastName='" + customer.lastName + "' " +
        "data-email='" + customer.email + "' " +
        "data-gender='" + customer.gender + "' " +
        "data-age='" + customer.age + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Edit" +
        "</button> " +
        " <button type='button' " +
        "onClick='customerDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + customer.id + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        "</td>" +
        "</tr>";

    return newRow;
}

function onAddCustomer(item) {
    var options = {};
    options.url = "/api/customers/AddCustomer";
    options.type = "POST";

    var obj = Customer;
    obj.firstName = $("#firstName").val();
    obj.lastName = $("#lastName").val();
    obj.email = $("#email").val();
    obj.gender = $("#gender").val();
    obj.age = $("#age").val();
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";

    options.success = function (msg) {
        getCustomerList();
        $("#msg").html(msg);
        $("#firstName").val('');
        $("#lastName").val('');
        $("#email").val('');
        $("#gender").val('');
        $("#age").val('');
    },
        options.error = function () {
            $("#msg").html("Error while calling the web API!");
        };
    $.ajax(options);

}
function customerUpdate(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "api/customers/EditCustomer/";
    options.type = "PUT";

    var obj = Customer;
    obj.id = $(item).data("id");
    obj.firstName = $(".input-firstName", $(item).parent().parent()).val();
    obj.lastName = $(".input-lastName").val();
    obj.email = $(".input-email").val();
    obj.gender = $(".input-gender").val();
    obj.age = $(".input-age").val();

    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";

    options.success = function (msg) {
        console.log('msg=' + msg);
        $("#msg").html(msg);
        getCustomerList();
    },
        options.error = function () {
            $("#msg").html("Error while calling the web API!");
        };
    $.ajax(options);
}

function customerDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "api/customers/DeleteCustomer/"
        + id;
    options.type = "DELETE";
    options.dataType = "html";

    options.success = function (msg) {
        console.log('msg=' + msg);
        $("#msg").html(msg);
        getCustomerList();
    };
    options.error = function () {
        $("#msg").html("error while calling the web api!");
    };
    $.ajax(options);
}

function handleException(request, message, error) {
    var msg = "";
    msg += "Code:" + request.status + "\n";
    msg += "Text" + request.statusText + "\n";
    if (request.responseJson != null) {
        msg += "Message:" + request.responseJson.Message + "\n";

    }
    alert(msg);
}
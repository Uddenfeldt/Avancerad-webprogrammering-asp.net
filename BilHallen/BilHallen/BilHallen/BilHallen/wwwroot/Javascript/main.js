$(document).ready(function () {
    getCarList();
});

var Car = {
    manufacturer,
    model,
    transmission,
    regNumber,
    type,
    numberOfOwners,
    year,
    color,
    kilometers,
    price,
    horsePowers,
    city,
    imageUrl
};

function getCarList() {
    $.ajax({
        url: 'api/Cars/GetCars',
        method: 'GET',
        dataType: 'JSON',
        success: function (cars) {

            carListSucces(cars);
        },

        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function carListSucces(car) {
    $("#carTable tbody").remove();
    $.each(car, function (index, car) {
        carAddRow(car);
    });

}

function carAddRow(car) {
    if ($("#carTable tbody").length === 0) {
        $("#carTable").append("<tbody></tbody>");
    }

    $("#carTable tbody").append(
        carBuildTableRow(car));
}

function carBuildTableRow(car) {
    var newRow = "<tr>" +
        "<td>" + car.id + "</td>" +
        "<td id=image><a href='" + car.imageUrl + "'><img src='" + car.imageUrl + "'/></a></td> " +
        "<td><input class='input-manufacturer' type='text' value='" + car.manufacturer + "'/></td>" +
        "<td><input class='input-model' type='text' value='" + car.model + "' /></td>" +
        "<td><input class='input-transmission' type='text' value='" + car.transmission + "' /></td>" +
        "<td><input class='input-regNumber type='text' value='" + car.regNumber + "' /></td>" +
        "<td><input class='input-type type='text' value='" + car.type + "' /></td>" +
        "<td><input class='input-numberOfOwners type='text' value='" + car.numberOfOwners + "' /></td>" +
        "<td><input class='input-year type='text' value='" + car.year + "' /></td>" +
        "<td><input class='input-color type='text' value='" + car.color + "' /></td>" +
        "<td><input class='input-kilometers type='text' value='" + car.kilometers + "' /></td>" +
        "<td><input class='input-price type='text' value='" + car.price + "' /></td>" +
        "<td><input class='input-horsePowers type='text' value='" + car.horsePowers + "' /></td>" +
        "<td><input class='input-city' type='text' value='" + car.city + "' /></td>" +
        "<td>" +
        "<button type='button' " +
        "onClick='carUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + car.id + "' " +
        "data-manufacturer='" + car.manufacturer + "' " +
        "data-model='" + car.model + "' " +
        "data-transmission='" + car.transmission + "' " +
        "data-regNumber='" + car.regNumber + "' " +
        "data-type='" + car.type + "' " +
        "data-numberOfOwners='" + car.numberOfOwners + "' " +
        "data-year='" + car.year + "' " +
        "data-color='" + car.color + "' " +
        "data-kilometers='" + car.kilometers + "' " +
        "data-price='" + car.price + "' " +
        "data-horsePowers='" + car.horsePowers + "' " +
        "data-city='" + car.city + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Edit" +
        "</button> " +
        " <button type='button' " +
        "onClick='carDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + car.id + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        " <button type='button' " +
        "onClick='getCarInfo(this);'" +
        "class='btn btn-default' " +
        "data-id='" + car.id + "'>" +
        "<span class='glyphicon glyphicon-info' />Info" +
        "</button>" +
        
        "</td>" +
        "</tr>";

    return newRow;
}

function AddCar(item) {
    var options = {};
    options.url = "/api/cars/AddCar";
    options.type = "POST";

    var obj = Car;
    obj.manufacturer = $("#manufacturer").val();
    obj.model = $("#model").val();
    obj.transmission = $("#transmission").val();
    obj.regNumber = $("#regNumber").val();
    obj.type = $("#type").val();
    obj.numberOfOwners = $("#numberOfOwners").val();
    obj.year = $("#year").val();
    obj.color = $("#color").val();
    obj.kilometers = $("#kilometers").val();
    obj.price = $("#price").val();
    obj.horsePowers = $("#horsePowers").val();
    obj.city = $("#city").val();
    obj.imageUrl = $("#imageUrl").val();
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";

    options.success = function (msg) {
        getCarList();
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

function carUpdate(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "api/cars/EditCar/";
    options.type = "PUT";

    var obj = Car;
    obj.id = $(item).data("id");
    obj.manufacturer = $(".input-manufacturer", $(item).parent().parent()).val();
    obj.model = $(".input-model", $(item).parent().parent()).val();
    obj.transmission = $(".input-transmission", $(item).parent().parent()).val();
    obj.regNumber = $(".input-regnumber", $(item).parent().parent()).val();
    obj.type = $(".input-type", $(item).parent().parent()).val();
    obj.numberOfOwners = $(".input-numberOfOwners", $(item).parent().parent()).val();
    obj.year = $(".input-year", $(item).parent().parent()).val();
    obj.color = $(".input-color", $(item).parent().parent()).val();
    obj.kilometers = $(".input-kilometers", $(item).parent().parent()).val();
    obj.price = $(".input-price", $(item).parent().parent()).val();
    obj.horsePowers = $(".input-horsePowers", $(item).parent().parent()).val();
    obj.city = $(".input-city", $(item).parent().parent()).val();
    

    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";

    options.success = function (msg) {
        console.log('msg=' + msg);
        $("#msg").html(msg);
        getCarList();
    },
        options.error = function () {
            $("#msg").html("Error while calling the web API!");
        };
    $.ajax(options);
}
function carDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "api/cars/DeleteCar/"
        + id;
    options.type = "DELETE";
    options.dataType = "html";

    options.success = function (msg) {
        console.log('msg=' + msg);
        $("#msg").html(msg);
        getCarList();
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

function getCarInfo(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "api/cars/getcar/"
        + id;
    options.type = "GET";
    options.dataType = "html";

    options.success = function (msg) {
        console.log('msg=' + msg);
        $("#msg").html(msg);
        getCar();
    };

    options.error = function () {
        $("#msg").html("error while calling the web api!");
    };
    $.ajax(options);
}
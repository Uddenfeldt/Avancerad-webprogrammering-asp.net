function clear() {
    $("#succesMessage").text("")
    $("errorMessage").text("")
}

$("#knapp").click(function () {

    let n = $("#enteredNumber").val();

    $.ajax({
        url: '/person/findcustomer',
        method: 'GET',
        data: { id: n }
    })
        .done(function (result) {
            console.log("Succes", result)
            clear()
            $("#succesMessage").text(result)
        })
        .fail(function (xhr, status, error) {
            console.log("Fail", xhr)
            clear()
            $("#errorMessage").text(xhr.responseText)
        })

});
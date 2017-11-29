function clear() {
    $("#succesMessage").text("")
    $("errorMessage").text("")
}

$("#knapp").click(function () {

    let n = $("#enteredNumber").val();
    let b = $("#isBrief").is(":checked");

    $.ajax({
        url: '/person/findcustomer',
        method: 'GET',
        data: {
            id: n,
            isBrief: b
        }
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
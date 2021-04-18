// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    var _apiPath = "https://mypremiumcalculatorapi.azurewebsites.net/api";    

    // Load occupations
    $.ajax({
        type: "GET",
        url: _apiPath + "/Occupation",               
        success: function (data) {
            var s = '<option value="-1">Please select a occupation</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].id + '" data-ratingDetail="' + data[i].ratingDetail.id + '">' + data[i].name + '</option>';
            }
            $("#ddlOccupation").html(s);
        }
    });

    // Calculate the premium on age/occupation/deathSumInsured change
    $(".triggerCalculation").change(function () {
        var age = $("#txtAge").val();
        var occupationID = $("#ddlOccupation").find(":selected").data("ratingdetail");
        var deathSumInsured = $("#txtDeathSumInsured").val();

        if (age && occupationID && deathSumInsured) {
            calculatePremium();
        }
    });

    // Calculate actual premium
    var calculatePremium = function () {
        var calculatorParamaters = {
            name: $("#txtName").val(),
            age: $("#txtAge").val(),
            dbo: $("#txtDOB").val(),
            occupationID: $("#ddlOccupation").find(":selected").data("ratingdetail"),
            deathSumInsured: $("#txtDeathSumInsured").val()
        };

        $.ajax({
            type: "POST",
            url: _apiPath + "/Calculator",
            accepts: "application/json",
            contentType: "application/json",
            data: JSON.stringify(calculatorParamaters),
            success: function (data) {
                $("#txtPremium").html("$" + data);
            },
            error: function () {
                $("#txtPremium").html("Some error, please try again later.");
            }
        });
    };
}); 
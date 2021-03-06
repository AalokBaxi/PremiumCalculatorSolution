// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    var _apiPath = "http://localhost:1777/api";    
    // var _apiPath = "https://mypremiumcalculatorapi.azurewebsites.net/api";   

    // Load occupations
    $.ajax({
        type: "GET",
        url: _apiPath + "/Occupation",  
        beforeSend: function () {
            $("#spOccupationLoading").addClass("spinner-border");
        },
        complete: function () {
            $("#spOccupationLoading").removeClass("spinner-border");
        },
        success: function (data) {
            var s = '<option value="-1">Please select a occupation</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].id + '" data-ratingDetail="' + data[i].ratingDetail.id + '">' + data[i].name + '</option>';
            }
            $("#ddlOccupation").html(s);
        }
    });

    $("#txtDOB").change(function () {
        var dob = new Date($(this).val());
        var today = new Date();

        var age = today.getFullYear() - dob.getFullYear();
        var monthDifference = today.getMonth() - dob.getMonth();
        if (monthDifference < 0 || (monthDifference === 0 && today.getDate() < dob.getDate())) {
            // If dob month is greater than current month then return --age
            // or If dob is greater than current date then return -1            
            age--;
        }

        // Dob range validation: between 1 and 150
        if (age <= 0 || age > 150) {
            $(this).addClass("is-invalid");
            $("#lblDOBError").removeClass("text-hide").addClass("invalid-feedback");
            $("#txtAge").val(age);
            resetPremium();
        }
        else {
            $(this).removeClass("is-invalid");
            $("#lblDOBError").addClass("text-hide").removeClass("invalid-feedback");

            // Set age and trigger change event
            $("#txtAge").val(age).trigger("change");

        }        
    });

    // Calculate the premium on age/occupation/deathSumInsured change
    $(".triggerCalculation").change(function () {
        var age = $("#txtAge").val();
        var occupationID = $("#ddlOccupation").find(":selected").val();
        var deathSumInsured = $("#txtDeathSumInsured").val();
        
        if (age && age > 0 && occupationID && occupationID > 0 && deathSumInsured && deathSumInsured > 0) {
            calculatePremium();
        }
        else {
            resetPremium();
        }        
    });

    // Show - in premium label
    var resetPremium = function () {
        $("#txtPremium").empty();
        $("#txtPremium").html("-");
    };

    // Calculate actual premium
    var calculatePremium = function () {
        var calculatorParamaters = {
            name: $("#txtName").val(),
            age: $("#txtAge").val(),
            dbo: $("#txtDOB").val(),
            occupationID: $("#ddlOccupation").find(":selected").val(),
            deathSumInsured: $("#txtDeathSumInsured").val()
        };

        $.ajax({
            type: "POST",
            url: _apiPath + "/Calculator",
            accepts: "application/json",
            contentType: "application/json",
            data: JSON.stringify(calculatorParamaters),
            beforeSend: function () {
                $("#txtPremium").empty();
                $("#txtPremium").addClass("spinner-border");
            },            
            success: function (data) {                
                $("#txtPremium").removeClass("spinner-border");
                $("#txtPremium").html("$" + data).append("<small class='text - muted'> / mo</small>");
            },
            error: function () {
                $("#txtPremium").removeClass("spinner-border");
                $("#txtPremium").html(": Some error, please try again later.");
            }
        });
    };
}); 
function populateContact(data) {


            $('#firstName').val(data.firstName);
            $('#lastName').val(data.lastName);
            $('#email').val(data.email);
            $('#phone').val(data.phone);
            $('#dateOfBirth').val(formatDate(data.dateOfBirth));
            $('#phone').val(data.phone);
            $('#address').val(data.address);

}

function populateSummary(data) {

    $('#summary').val(data.content);

}

$(document).ready(function () {
    // Function to handle input changes
    function handleInputChange(event) {


        var inputName = event.target.name;
        var inputValue = event.target.value;
        console.log("Name: " + inputName + ", Value: " + inputValue);

        var toUpdate = {
            PropName: inputName,
            PropValue: inputValue
        };

        $.ajax({
            url: `/Resume/UpdateDynamic/${resumeId}`,
            method: "PUT",
            data: toUpdate,
            success: function (response) {
                // Handle success, e.g., display a success message
                console.log("Entry updated successfully!");
            },
            error: function (error) {
                // Handle error, e.g., display an error message
                console.error("Failed to update entry:", error);
            }
        });
    }

    function handleSummaryChange(event) {


        var inputName = event.target.name;
        var content = event.target.value;
        console.log("Name: " + inputName + ", Value: " + content);
        var data = JSON.stringify(content);

        $.ajax({
            url: `/Resume/UpdateSummary/${resumeId}`,
            method: "PUT",
            data: data,
            contentType: "application/json",
            success: function (response) {
                // Handle success, e.g., display a success message
                console.log("Entry updated successfully!");
            },
            error: function (error) {
                // Handle error, e.g., display an error message
                console.error("Failed to update entry:", error);
            }
        });
    }

    // Attach onchange event handler to all input elements
    $('#personalDetailForm input, #personalDetailForm textarea').on('change', handleInputChange);
    $('#summary').on('change', handleSummaryChange);
});


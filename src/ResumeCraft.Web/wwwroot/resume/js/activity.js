$('#add-activity').click(function () {
    // Increment the activityCounter to get a new unique ID
    activityCounter++;

    const activitySectionId = `activitySection-${activityCounter}`;
    const cardId = `card-${activitySectionId}`;

    const activitySection = `
                <div class="card card-body mt-3 activity-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${activitySectionId}" role="button" aria-expanded="false" aria-controls="${activitySectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn remove-entry" data-card-id="${cardId}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${activitySectionId}">
                        <form asp-action="SaveActivity" method="post" class="activity-form" data-activity-id="${activitySectionId}" >

                        <div class="activity">

                             <div class="row mt-4">
                                 <div class="col-lg-6">
                                     <lebel class="fw-light ">Position</lebel>
                                     <input class="form-control bg-body-secondary" required autocomplete="off" name="Title"/>
                                 </div>
                                 <div class="col-lg-6">
                                     <lebel class="fw-light">Organization</lebel>
                                     <input class="form-control bg-body-secondary" required autocomplete="off" name="Organization"/>
                                 </div>
                             </div>
                             <div class="row mt-4">
                                 <div class="col-lg-6">
                                     <lebel class="fw-light">Start</lebel>
                                     <input class="form-control bg-body-secondary" type="date" required autocomplete="off" name="StartDate"/>
                                 </div>
                                 <div class="col-lg-6">
                                     <lebel class="fw-light">End</lebel>
                                     <input class="form-control bg-body-secondary" type="date" required autocomplete="off" name="EndDate"/>
                                 </div>
                             </div>

                        <div class="d-flex align-items-end flex-column">
                          <div class="mt-auto p-2">
                              <button type="submit" class="btn save-activity mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px;">Save</button>
                          </div>
                        </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

    $(".activities").append(activitySection);
});


function populateActivity(activityData) {
    const activitysContainer = $(".getActivities");
    activitysContainer.empty();

    activityData.forEach((activity, index) => {
        activityCounter++;
        //activityCounter = `activitySection-${index}`;

        // Generate a unique ID for each activity section
        const activitySectionId = `activitySection-${activityCounter}`;
        const cardId = `card-${activitySectionId}`;

        // Create the HTML for the activity section
        const activitySection = `
                <div class="card card-body mt-3 activity-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"><p>${activity.title || ''}</p></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${activitySectionId}" role="button" aria-expanded="false" aria-controls="${activitySectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn delete delete-entry-activity" data-card-id="${cardId}" data-delete-id="${activity.id || ''}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${activitySectionId}">
                        <form asp-action="UpdateActivity" method="post" class="activity-update-form" data-activity-id="${activitySectionId}" >

                        <input type="hidden" value="${activity.id || ''}" name="Id" />

                        <div class="activity">
                           <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Title</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${activity.title || ''}" name="Title"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Institution</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${activity.organization || ''}" name="Organization"/>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light">Start</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off"  value="${formatDate(activity.startDate) || ''}"  name="StartDate"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">End</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" value="${formatDate(activity.endDate) || ''}"  name="EndDate"/>
                            </div>
                        </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
 <button type="button" class="btn edit-activity mt-3" data-activity-id="${activitySectionId}"><i class="fa-regular fa-pen-to-square"></i></button>
        <button type="button" class="btn cancel-activity mt-3" data-activity-id="${activitySectionId}" style="background-color: grey; color: white; width: 100px; display: none;">Cancel</button>

                                    <button type="submit" class="btn update-activity mt-3"  style="background-color: #FF914D; color: white; width: 100px; display: none;">Save</button>
                                </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

        activitysContainer.append(activitySection);
    });

    $(".activity-update-form input").prop("disabled", true);

    // Enable edit mode for a activity section
    $(document).on('click', '.edit-activity', function () {
        const activityId = $(this).data('activity-id');
        $(`#${activityId} input`).prop('disabled', false); // Enable form fields
        $(`#${activityId} .edit-activity`).hide(); // Hide the "Edit" button
        $(`#${activityId} .update-activity`).show(); // Show the "Save" button
        $(`#${activityId} .cancel-activity`).show(); // Show the "Cancel" button
    });

    // Handle the "Cancel" action
    $(document).on('click', '.cancel-activity', function () {
        const activityId = $(this).data('activity-id');
        $(`#${activityId} input`).prop('disabled', true); // Disable form fields
        $(`#${activityId} .edit-activity`).show(); // Show the "Edit" button
        $(`#${activityId} .update-activity`).hide(); // Hide the "Save" button
        $(`#${activityId} .cancel-activity`).hide(); // Hide the "Cancel" button
    });

}


function populateUpdatedActivity() {

    $.ajax({
        url: `/Resume/GetActivities/${resumeId}`,
        method: "GET",
        success: function (data) {
            // Call the function to populate sections with child elements
            populateActivity(data);
        },
        error: function () {
            console.error("Failed to retrieve resume data.");
        }
    });
}


$(document).on("submit", ".activity-form", function (e) {
    e.preventDefault();

    const form = $(this);
    const cardRemoveId = form.find(".save-skill").data("card-id"); // Get the data-card-id from the submit button

    const formData = form.serialize();

    $.ajax({
        url: `/Resume/CreateActivity/${resumeId}`,
        method: "POST",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("activity saved successfully!");
            $(`#${cardRemoveId}`).remove();
            populateUpdatedActivity();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to save activity:", error);
        }
    });
});


// Handle updating a entry
$(document).on("submit", ".activity-update-form", function (e) {
    e.preventDefault();

    const form = $(this);

    const formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/UpdateActivity/${resumeId}`,
        method: "PUT",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Entry updated successfully!");
            populateUpdatedActivity();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to update entry:", error);
        }
    });

});


// Handle deleting a entry
$(document).on('click', '.delete-entry-activity', function () {
    const cardRemoveId = $(this).data('card-id');
    const entryDeleteId = $(this).data('delete-id');

    // Show the confirmation modal
    $('#confirmationModal').modal('show');

    // Handle deletion when the user clicks "Delete"
    $('#confirmDelete').on('click', function () {

        $.ajax({
            url: `/Resume/${resumeId}/DeleteActivity/${entryDeleteId}`,
            method: "DELETE",
            success: function (response) {
                // Handle success, e.g., display a success message
                $(`#${cardRemoveId}`).remove();

                console.log("Entry delete successfully!");
            },
            error: function (error) {
                // Handle error, e.g., display an error message
                console.error("Failed to delete entry:", error);
            }
        });

        // Close the modal
        $('#confirmationModal').modal('hide');
    });
});

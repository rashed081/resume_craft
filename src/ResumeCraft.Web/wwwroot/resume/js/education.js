$('#add-education').click(function () {
    // Increment the educationCounter to get a new unique ID
    educationCounter++;

    const educationSectionId = `educationSection-${educationCounter}`;
    const cardId = `card-${educationSectionId}`;

    const educationSection = `
                <div class="card card-body mt-3 education-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${educationSectionId}" role="button" aria-expanded="false" aria-controls="${educationSectionId}">
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
                    <div class="collapse" id="${educationSectionId}">
                        <form asp-action="SaveEducation" method="post" class="education-form" data-education-id="${educationSectionId}" >

                        <div class="education">
                            <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">School</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="InstituteName" />
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Degree</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="FieldOfStudy" />
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">City</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="City" />
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Country</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="Country" />
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Grade</lebel>
                                <input type="text" class="form-control bg-body-secondary" required autocomplete="off" pattern="[0-9]+(\.[0-9][0-9]?)?" min="0" max="4" name="Grade" />
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light">Start</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" name="StartDate" />
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">End</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" name="EndDate" />
                            </div>
                        </div>
                        <div class="d-flex align-items-end flex-column">
                          <div class="mt-auto p-2">
                              <button type="submit" class="btn save-education mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px;">Save</button>
                          </div>
                        </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

    $(".educations").append(educationSection);
});



function populateEducation(educationData) {
    const educationsContainer = $(".getEducations");
    educationsContainer.empty();

    educationData.forEach((education, index) => {
        educationCounter++;
        //educationCounter = `educationSection-${index}`;

        // Generate a unique ID for each education section
        const educationSectionId = `educationSection-${educationCounter}`;
        const cardId = `card-${educationSectionId}`;

        // Create the HTML for the education section
        const educationSection = `
                <div class="card card-body mt-3 education-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"><p>${education.instituteName || ''}</p></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${educationSectionId}" role="button" aria-expanded="false" aria-controls="${educationSectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn delete delete-entry-education" data-card-id="${cardId}" data-delete-id="${education.id || ''}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${educationSectionId}">
                        <form asp-action="UpdateEducation" method="post" class="education-update-form" data-education-id="${educationSectionId}" >

                        <input type="hidden" value="${education.id || ''}" name="Id" />

                        <div class="education">
                          <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">School</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${education.instituteName || ''}" name="InstituteName" />
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Degree</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${education.fieldOfStudy || ''}" name="FieldOfStudy" />
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">City</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${education.city || ''}" name="City" />
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Country</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${education.country || ''}" name="Country" />
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Grade</lebel>
                                <input type="text" class="form-control bg-body-secondary" required autocomplete="off" pattern="[0-9]+(\.[0-9][0-9]?)?" min="0" max="4" value="${education.grade || ''}" name="Grade" />
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light">Start</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" value="${formatDate(education.startDate) || ''}" name="StartDate" />
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">End</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" value="${formatDate(education.endDate) || ''}" name="EndDate" />
                            </div>
                        </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
 <button type="button" class="btn edit-education mt-3" data-education-id="${educationSectionId}"><i class="fa-regular fa-pen-to-square"></i></button>
        <button type="button" class="btn cancel-education mt-3" data-education-id="${educationSectionId}" style="background-color: grey; color: white; width: 100px; display: none;">Cancel</button>

                                    <button type="submit" class="btn update-education mt-3" style="background-color: #FF914D; color: white; width: 100px; display: none;">Save</button>
                                </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

        educationsContainer.append(educationSection);
    });

    $(".education-update-form input").prop("disabled", true);

    // Enable edit mode for a education section
    $(document).on('click', '.edit-education', function () {
        const educationId = $(this).data('education-id');
        $(`#${educationId} input`).prop('disabled', false); // Enable form fields
        $(`#${educationId} .edit-education`).hide(); // Hide the "Edit" button
        $(`#${educationId} .update-education`).show(); // Show the "Save" button
        $(`#${educationId} .cancel-education`).show(); // Show the "Cancel" button
    });

    // Handle the "Cancel" action
    $(document).on('click', '.cancel-education', function () {
        const educationId = $(this).data('education-id');
        $(`#${educationId} input`).prop('disabled', true); // Disable form fields
        $(`#${educationId} .edit-education`).show(); // Show the "Edit" button
        $(`#${educationId} .update-education`).hide(); // Hide the "Save" button
        $(`#${educationId} .cancel-education`).hide(); // Hide the "Cancel" button
    });

}

// Get Educations
function populateUpdatedEducation() {

    $.ajax({
        url: `/Resume/GetEducations/${resumeId}`,
        method: "GET",
        success: function (data) {
            // Call the function to populate sections with child elements
            populateEducation(data);
        },
        error: function () {
            console.error("Failed to retrieve resume data.");
        }
    });
}

// Handle saving a entry
$(document).on("submit", ".education-form", function (e) {
    e.preventDefault();

    const form = $(this);
    const cardRemoveId = form.find(".save-education").data("card-id"); // Get the data-card-id from the submit button
    console.log("Card ID:", cardRemoveId);

    const formData = form.serialize();

    $.ajax({
        url: `/Resume/CreateEducation/${resumeId}`,
        method: "POST",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("education saved successfully!");
            $(`#${cardRemoveId}`).remove();
            populateUpdatedEducation();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to save education:", error);
        }
    });
});



// Handle updating a entry
$(document).on("submit", ".education-update-form", function (e) {
    e.preventDefault();

    const form = $(this);

    const formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/UpdateEducation/${resumeId}`,
        method: "PUT",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Entry updated successfully!");
            populateUpdatedEducation();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to update entry:", error);
        }
    });

});


// Handle deleting a entry
$(document).on('click', '.delete-entry-education', function () {
    const cardRemoveId = $(this).data('card-id');
    const entryDeleteId = $(this).data('delete-id');

    // Show the confirmation modal
    $('#confirmationModal').modal('show');

    // Handle deletion when the user clicks "Delete"
    $('#confirmDelete').on('click', function () {

        $.ajax({
            url: `/Resume/${resumeId}/DeleteEducation/${entryDeleteId}`,
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

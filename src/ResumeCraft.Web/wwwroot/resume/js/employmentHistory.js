$('#add-employmentHistory').click(function () {
    // Increment the experienceCounter to get a new unique ID
    experienceCounter++;

    const employmentHistorySectionId = `employmentHistorySection-${experienceCounter}`;
    const cardId = `card-${employmentHistorySectionId}`;

    const employmentHistorySection = `
                <div class="card card-body mt-3 employmentHistory-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${employmentHistorySectionId}" role="button" aria-expanded="false" aria-controls="${employmentHistorySectionId}">
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
                    <div class="collapse" id="${employmentHistorySectionId}">
                        <form asp-action="SaveEmploymentHistory" method="post" class="employmentHistory-form" data-employmentHistory-id="${employmentHistorySectionId}" >

                        <div class="employmentHistory">
                            <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Job Title</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="Designation"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Employer</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="CompanyName"/>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light">Start</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" name="StartDate"/>
                            </div>
                            <div class="col-lg-6">
                                <label class="fw-light">End</label>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" name="EndDate" id="EndDate-${experienceCounter}" />
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" id="currently-working-here-${experienceCounter}" data-end-date-id="EndDate-${experienceCounter}" />
                                    <label class="form-check-label" for="currently-working-here-${experienceCounter}">Currently working here</label>
                                </div>
                            </div>
                        </div>

                        <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light">Description</lebel>

                                <textarea class="form-control bg-body-secondary" type="text" style="height: 150px" required autocomplete="off" name="Achievement"></textarea>
                            </div>
                        </div>
                        <div class="d-flex align-items-end flex-column">
                          <div class="mt-auto p-2">
                              <button type="submit" class="btn save-experience mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px;">Save</button>
                          </div>
                        </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

    $(".experiences").append(employmentHistorySection);

});


// Populate updated experiences
function populateExperience(experienceData) {
    const experiencesContainer = $(".getExperiences");
    experiencesContainer.empty();

    experienceData.forEach((experience, index) => {
        experienceCounter++;
        //experienceCounter = `experienceSection-${index}`;

        // Generate a unique ID for each experience section
        const experienceSectionId = `experienceSection-${experienceCounter}`;
        const cardId = `card-${experienceSectionId}`;

        // Create the HTML for the experience section
        const experienceSection = `
                <div class="card card-body mt-3 experience-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"><p>${experience.companyName || ''}</p></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${experienceSectionId}" role="button" aria-expanded="false" aria-controls="${experienceSectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn delete delete-entry-experience" data-card-id="${cardId}" data-delete-id="${experience.id || ''}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${experienceSectionId}">
                        <form asp-action="UpdateExperience" method="post" class="experience-update-form" data-experience-id="${experienceSectionId}" >

                        <input type="hidden" value="${experience.id || ''}" name="Id" />

                        <div class="experience">
                          <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Job Title</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${experience.designation || ''}" name="Designation"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Employer</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${experience.companyName || ''}" name="CompanyName"/>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light">Start</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" value="${formatDate(experience.startDate) || ''}" name="startDate"/>
                            </div>
                            <div class="col-lg-6">
                                <label class="fw-light">End</label>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off" value="${formatDate(experience.endDate) || ''}" name="EndDate" id="EndDate-${experienceCounter}" />
                                <div class="form-check">
                                    <input type="checkbox" class="form-check-input" id="currently-working-here-${experienceCounter}" data-end-date-id="EndDate-${experienceCounter}" />
                                    <label class="form-check-label" for="currently-working-here-${experienceCounter}">Currently working here</label>
                                </div>
                            </div>
                        </div>

                        <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light">Description</lebel>

                                <textarea class="form-control bg-body-secondary" type="text" id="achievement" style="height: 150px" required autocomplete="off" name="Achievement">${experience.achievement || ''}</textarea>
                            </div>
                        </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
 <button type="button" class="btn edit-experience mt-3" data-experience-id="${experienceSectionId}"><i class="fa-regular fa-pen-to-square"></i></button>
        <button type="button" class="btn cancel-experience mt-3" data-experience-id="${experienceSectionId}" style="background-color: grey; color: white; width: 100px; display: none;">Cancel</button>

                                    <button type="submit" class="btn update-experience mt-3" style="background-color: #FF914D; color: white; width: 100px; display: none;">Save</button>
                                </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

        experiencesContainer.append(experienceSection);
    });

    $(".experience-update-form input").prop("disabled", true);

    // Enable edit mode for a experience section
    $(document).on('click', '.edit-experience', function () {
        const experienceId = $(this).data('experience-id');
        $(`#${experienceId} input`).prop('disabled', false); // Enable form fields
        $(`#achievement`).prop('disabled', false); // Disable form fields
        $(`#${experienceId} .edit-experience`).hide(); // Hide the "Edit" button
        $(`#${experienceId} .update-experience`).show(); // Show the "Save" button
        $(`#${experienceId} .cancel-experience`).show(); // Show the "Cancel" button
    });

    // Handle the "Cancel" action
    $(document).on('click', '.cancel-experience', function () {
        const experienceId = $(this).data('experience-id');
        $(`#${experienceId} input`).prop('disabled', true); // Disable form fields
        $(`#achievement`).prop('disabled', true); // Disable form fields
        $(`#${experienceId} .edit-experience`).show(); // Show the "Edit" button
        $(`#${experienceId} .update-experience`).hide(); // Hide the "Save" button
        $(`#${experienceId} .cancel-experience`).hide(); // Hide the "Cancel" button
    });

}

// Get updated experiences
function populateUpdatedExperience() {

    $.ajax({
        url: `/Resume/GetExperiences/${resumeId}`,
        method: "GET",
        success: function (data) {
            // Call the function to populate sections with child elements
            populateExperience(data);
        },
        error: function () {
            console.error("Failed to retrieve resume data.");
        }
    });
}


// Handle enabling/disabling the "End" date input when the checkbox changes
$(document).on('change', 'input[type="checkbox"]', function () {
    const endDateId = $(this).data('end-date-id');
    const endDateInput = $(`#${endDateId}`);

    if (this.checked) {
        endDateInput.prop('disabled', true);
    } else {
        endDateInput.prop('disabled', false);
    }
});


// Handle saving a entry
$(document).on("submit", ".employmentHistory-form", function (e) {
    e.preventDefault();

    const form = $(this);
    const cardRemoveId = form.find(".save-experience").data("card-id"); // Get the data-card-id from the submit button

    const formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/CreateExperience/${resumeId}`,
        method: "POST",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("employmentHistory saved successfully!");
            $(`#${cardRemoveId}`).remove();
            populateUpdatedExperience();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to save employmentHistory:", error);
        }
    });
});

// Handle updating a entry
$(document).on("submit", ".experience-update-form", function (e) {
    e.preventDefault();

    const form = $(this);

    const formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/UpdateExperience/${resumeId}`,
        method: "PUT",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Entry updated successfully!");
            populateUpdatedExperience();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to update entry:", error);
        }
    });

});

// Handle removing a section card
$(document).on('click', '.delete-entry-experience', function () {
    const cardRemoveId = $(this).data('card-id');
    const entryDeleteId = $(this).data('delete-id');

    // Show the confirmation modal
    $('#confirmationModal').modal('show');

    // Handle deletion when the user clicks "Delete"
    $('#confirmDelete').on('click', function () {

        $.ajax({
            url: `/Resume/${resumeId}/DeleteExperience/${entryDeleteId}`,
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

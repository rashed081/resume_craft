$('#add-reference').click(function () {
    // Increment the referenceCounter to get a new unique ID
    referenceCounter++;

    const referenceSectionId = `referenceSection-${referenceCounter}`;
    const cardId = `card-${referenceSectionId}`;
    const referenceSection = `
                <div class="card card-body mt-3 reference-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${referenceSectionId}" role="button" aria-expanded="false" aria-controls="${referenceSectionId}">
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
                    <div class="collapse" id="${referenceSectionId}">
                        <form asp-action="SaveReference" method="post" class="reference-form" data-reference-id="${referenceSectionId}" >

                        <div class="reference">
                            <div class="row mt-4">
                                <div class="col-lg-12">
                                    <label class="fw-light">Referent's Full Name</label>
                                    <input class="form-control bg-body-secondary" required autocomplete="off" name="SupervisorName" />
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-6">
                                    <label class="fw-light">Job Title</label>
                                            <input class="form-control bg-body-secondary" required autocomplete="off" name="SupervisorDesignation" />
                                </div>
                                <div class="col-lg-6">
                                    <label class="fw-light">Company</label>
                                    <input class="form-control bg-body-secondary" required autocomplete="off" name="SupervisorInstituteName" />
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-6">
                                    <label class="fw-light">Phone</label>
                                                    <input class="form-control bg-body-secondary" type="number" required autocomplete="off" name="SupervisorPhone" />
                                </div>
                                <div class="col-lg-6">
                                    <label class="fw-light">Email</label>
                                            <input class="form-control bg-body-secondary" type="email" required autocomplete="off" name="SupervisorEmail" />
                                </div>
                            </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
                                  <button type="submit" class="btn save-reference mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px;">Save</button>
                              </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

    $(".references").append(referenceSection);
});


function populateReference(referenceData) {
    const referencesContainer = $(".getReferences");
    referencesContainer.empty();
    //alert("hi");

    referenceData.forEach((reference, index) => {
        referenceCounter++;
        //referenceCounter = `referenceSection-${index}`;

        // Generate a unique ID for each reference section
        const referenceSectionId = `referenceSection-${referenceCounter}`;
        const cardId = `card-${referenceSectionId}`;

        // Create the HTML for the reference section
        const referenceSection = `
                <div class="card card-body mt-3 reference-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"><p>${reference.supervisorName || ''}</p></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${referenceSectionId}" role="button" aria-expanded="false" aria-controls="${referenceSectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn delete delete-entry-reference" data-card-id="${cardId}" data-delete-id="${reference.id || ''}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${referenceSectionId}">
                        <form asp-action="UpdateReference" method="post" class="reference-update-form" data-reference-id="${referenceSectionId}" >

                        <input type="hidden" value="${reference.id || ''}" name="Id" />

                        <div class="reference">
                            <div class="row mt-4">
                                <div class="col-lg-12">
                                    <label class="fw-light">Referent's Full Name</label>
                                    <input class="form-control bg-body-secondary" required autocomplete="off" value="${reference.supervisorName || ''}" name="SupervisorName" />
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-6">
                                    <label class="fw-light">Job Title</label>
                                    <input class="form-control bg-body-secondary" required autocomplete="off" value="${reference.supervisorDesignation || ''}" name="SupervisorDesignation" />
                                </div>
                                <div class="col-lg-6">
                                    <label class="fw-light">Company</label>
                                    <input class="form-control bg-body-secondary" required autocomplete="off" value="${reference.supervisorInstituteName || ''}" name="SupervisorInstituteName" />
                                </div>
                            </div>
                            <div class="row mt-4">
                                <div class="col-lg-6">
                                    <label class="fw-light">Phone</label>
                                    <input class="form-control bg-body-secondary" type="number" required autocomplete="off" value="${reference.supervisorPhone || ''}" name="SupervisorPhone" />
                                </div>
                                <div class="col-lg-6">
                                    <label class="fw-light">Email</label>
                                    <input class="form-control bg-body-secondary" type="email" required autocomplete="off" value="${reference.supervisorEmail || ''}" name="SupervisorEmail" />
                                </div>
                            </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
 <button type="button" class="btn edit-reference mt-3" data-reference-id="${referenceSectionId}"><i class="fa-regular fa-pen-to-square"></i></button>
        <button type="button" class="btn cancel-reference mt-3" data-reference-id="${referenceSectionId}" style="background-color: grey; color: white; width: 100px; display: none;">Cancel</button>

                        <button type="submit" class="btn update-reference mt-3" style="background-color: #FF914D; color: white; width: 100px; display: none;">Save</button>                              </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

        referencesContainer.append(referenceSection);
    });

    $(".reference-update-form input").prop("disabled", true);

    // Enable edit mode for a reference section
    $(document).on('click', '.edit-reference', function () {
        const referenceId = $(this).data('reference-id');
        $(`#${referenceId} input`).prop('disabled', false); // Enable form fields
        $(`#${referenceId} .edit-reference`).hide(); // Hide the "Edit" button
        $(`#${referenceId} .update-reference`).show(); // Show the "Save" button
        $(`#${referenceId} .cancel-reference`).show(); // Show the "Cancel" button
    });

    // Handle the "Cancel" action
    $(document).on('click', '.cancel-reference', function () {
        const referenceId = $(this).data('reference-id');
        $(`#${referenceId} input`).prop('disabled', true); // Disable form fields
        $(`#${referenceId} .edit-reference`).show(); // Show the "Edit" button
        $(`#${referenceId} .update-reference`).hide(); // Hide the "Save" button
        $(`#${referenceId} .cancel-reference`).hide(); // Hide the "Cancel" button
    });


}

// Get References
function populateUpdatedReference() {

    $.ajax({
        url: `/Resume/GetReferences/${resumeId}`,
        method: "GET",
        success: function (referenceData) {
            // Call the function to populate sections with child elements
            populateReference(referenceData);
        },
        error: function () {
            console.error("Failed to retrieve resume data.");
        }
    });
}


$(document).on("submit", ".reference-form", function (e) {
    e.preventDefault();

    const form = $(this);

    const cardRemoveId = form.find(".save-reference").data("card-id"); // Get the data-card-id from the submit button
    console.log("Card ID:", cardRemoveId);

    const formData = form.serialize();
    
    $.ajax({
        url: `/Resume/CreateReference/${resumeId}`, 
        method: "POST",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Reference saved successfully!");
            $(`#${cardRemoveId}`).remove();
            populateUpdatedReference();

        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to save reference:", error);
        }
    });

});




$(document).on("submit", ".reference-update-form", function (e) {
    e.preventDefault();

    const referenceForm = $(this);

    const formData = referenceForm.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/UpdateReference/${resumeId}`,
        method: "PUT",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Entry updated successfully!");
            populateUpdatedReference();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to update entry:", error);
        }
    });

});



// Handle removing a section card
$(document).on('click', '.delete-entry-reference', function () {
    const cardRemoveId = $(this).data('card-id');
    const entryDeleteId = $(this).data('delete-id');

    // Show the confirmation modal
    $('#confirmationModal').modal('show');

    // Handle deletion when the user clicks "Delete"
    $('#confirmDelete').on('click', function () {

        $.ajax({
            url: `/Resume/${resumeId}/DeleteReference/${entryDeleteId}`,
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






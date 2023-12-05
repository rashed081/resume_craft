$('#add-skill').click(function () {
    // Increment the skillCounter to get a new unique ID
    skillCounter++;

    const skillSectionId = `skillSection-${skillCounter}`;
    const cardId = `card-${skillSectionId}`;

    const skillSection = `
                <div class="card card-body mt-3 skill-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${skillSectionId}" role="button" aria-expanded="false" aria-controls="${skillSectionId}">
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
                    <div class="collapse" id="${skillSectionId}">
                        <form asp-action="SaveSkill" method="post" class="skill-form" data-skill-id="${skillSectionId}" >

                        <div class="skill">
                            <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Skill</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="Name"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Level</lebel>
                                <select class="form-control bg-body-secondary" name="Level" id="level">
                                    <option value="1">Beginner</option>
                                    <option value="2">Experienced</option>
                                    <option value="3">Expert</option>
                                </select>
                            </div>
                        </div>
                        <div class="d-flex align-items-end flex-column">
                          <div class="mt-auto p-2">
                              <button type="submit" class="btn save-skill mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px;">Save</button>
                          </div>
                        </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

    $(".skills").append(skillSection);
});


function populateSkill(skillData) {
    const skillsContainer = $(".getSkills");
    skillsContainer.empty();

    skillData.forEach((skill, index) => {
        skillCounter++;
        //skillCounter = `skillSection-${index}`;

        // Generate a unique ID for each skill section
        const skillSectionId = `skillSection-${skillCounter}`;
        const cardId = `card-${skillSectionId}`;

        // Create the HTML for the skill section
        const skillSection = `
                <div class="card card-body mt-3 skill-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"><p>${skill.name || ''}</p></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${skillSectionId}" role="button" aria-expanded="false" aria-controls="${skillSectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn delete delete-entry-skill" data-card-id="${cardId}" data-delete-id="${skill.id || ''}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${skillSectionId}">
                        <form asp-action="UpdateSkill" method="post" class="skill-update-form" data-skill-id="${skillSectionId}" >

                        <input type="hidden" value="${skill.id || ''}" name="Id" />

                        <div class="skill">
                          <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Skill</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${skill.name || ''}" name="Name"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Level</lebel>
                                <select class="form-control bg-body-secondary" value="${skill.level || ''}" name="Level" id="level">
                                    <option value="1">Beginner</option>
                                    <option value="2">Experienced</option>
                                    <option value="3">Expert</option>
                                </select>
                            </div>
                        </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
 <button type="button" class="btn edit-skill mt-3" data-skill-id="${skillSectionId}"><i class="fa-regular fa-pen-to-square"></i></button>
        <button type="button" class="btn cancel-skill mt-3" data-skill-id="${skillSectionId}" style="background-color: grey; color: white; width: 100px; display: none;">Cancel</button>

                                    <button type="submit" class="btn update-skill mt-3"  style="background-color: #FF914D; color: white; width: 100px; display: none;">Save</button>
                                </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

        skillsContainer.append(skillSection);
    });

    $(".skill-update-form input").prop("disabled", true);

    // Enable edit mode for a skill section
    $(document).on('click', '.edit-skill', function () {
        const skillId = $(this).data('skill-id');
        $(`#${skillId} input`).prop('disabled', false); // Enable form fields
        $(`#${skillId} .edit-skill`).hide(); // Hide the "Edit" button
        $(`#${skillId} .update-skill`).show(); // Show the "Save" button
        $(`#${skillId} .cancel-skill`).show(); // Show the "Cancel" button
    });

    // Handle the "Cancel" action
    $(document).on('click', '.cancel-skill', function () {
        const skillId = $(this).data('skill-id');
        $(`#${skillId} input`).prop('disabled', true); // Disable form fields
        $(`#${skillId} .edit-skill`).show(); // Show the "Edit" button
        $(`#${skillId} .update-skill`).hide(); // Hide the "Save" button
        $(`#${skillId} .cancel-skill`).hide(); // Hide the "Cancel" button
    });

}


function populateUpdatedSkill() {

    $.ajax({
        url: `/Resume/GetSkills/${resumeId}`,
        method: "GET",
        success: function (data) {
            // Call the function to populate sections with child elements
            populateSkill(data);
        },
        error: function () {
            console.error("Failed to retrieve resume data.");
        }
    });
}


$(document).on("submit", ".skill-form", function (e) {
    e.preventDefault();

    const form = $(this);
    const cardRemoveId = form.find(".save-skill").data("card-id"); // Get the data-card-id from the submit button

    const formData = form.serialize();

    console.log("Form Data:", formData);

    $.ajax({
        url: `/Resume/CreateSkill/${resumeId}`,
        method: "POST",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("skill saved successfully!");
            $(`#${cardRemoveId}`).remove();
            populateUpdatedProject();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to save skill:", error);
        }
    });
});


// Handle updating a entry
$(document).on("submit", ".skill-update-form", function (e) {
    e.preventDefault();

    const form = $(this);

    const formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/UpdateSkill/${resumeId}`,
        method: "PUT",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Entry updated successfully!");
            populateUpdatedSkill();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to update entry:", error);
        }
    });

});


// Handle deleting a entry
$(document).on('click', '.delete-entry-skill', function () {
    const cardRemoveId = $(this).data('card-id');
    const entryDeleteId = $(this).data('delete-id');

    // Show the confirmation modal
    $('#confirmationModal').modal('show');

    // Handle deletion when the user clicks "Delete"
    $('#confirmDelete').on('click', function () {

        $.ajax({
            url: `/Resume/${resumeId}/DeleteSkill/${entryDeleteId}`,
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

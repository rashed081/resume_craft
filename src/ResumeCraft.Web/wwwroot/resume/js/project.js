$('#add-project').click(function () {
    // Increment the projectCounter to get a new unique ID
    projectCounter++;

    const projectSectionId = `projectSection-${projectCounter}`;
    const cardId = `card-${projectSectionId}`;

    const projectSection = `
                <div class="card card-body mt-3 project-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${projectSectionId}" role="button" aria-expanded="false" aria-controls="${projectSectionId}">
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
                    <div class="collapse" id="${projectSectionId}">
                        <form asp-action="SaveProject" method="post" class="project-form" data-project-id="${projectSectionId}" >

                        <div class="project">
                            <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light ">Project Title</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="ProjectName"/>
                            </div>
                            </div>
                        <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light ">Url</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="RepositoryUrl"/>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light">Description</lebel>

                                <textarea class="form-control bg-body-secondary" type="text" style="height: 150px" required autocomplete="off" name="Description"></textarea>
                            </div>
                        </div>
                        <div class="d-flex align-items-end flex-column">
                          <div class="mt-auto p-2">
                              <button type="submit" class="btn save-project mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px;">Save</button>
                          </div>
                        </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

    $(".projects").append(projectSection);
});

function populateProject(projectData) {
    const projectsContainer = $(".getProjects");
    projectsContainer.empty();
    //alert("hi");
    projectData.forEach((project, index) => {
        projectCounter++;
        //projectCounter = `projectSection-${index}`;

        // Generate a unique ID for each project section
        const projectSectionId = `projectSection-${projectCounter}`;
        const cardId = `card-${projectSectionId}`;
        //alert("Hello");

        // Create the HTML for the project section
        const projectSection = `
                <div class="card card-body mt-3 project-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"><p>${project.projectName || ''}</p></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${projectSectionId}" role="button" aria-expanded="false" aria-controls="${projectSectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn delete delete-entry-project" data-card-id="${cardId}" data-delete-id="${project.id || ''}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${projectSectionId}">
                        <form asp-action="Updateproject" method="post" class="project-update-form" data-project-id="${projectSectionId}" >

                        <input type="hidden" value="${project.id || ''}" name="Id" />

                        <div class="project">
                           <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light ">Project Title</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" ${project.projectName || ''} name="ProjectName"/>
                            </div>
                            </div>
                        <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light ">Url</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" ${project.repositoryUrl || ''} name="RepositoryUrl"/>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-lg-12">
                                <lebel class="fw-light">Description</lebel>

                                <textarea class="form-control bg-body-secondary" id="projectDescription" type="text" style="height: 150px" required autocomplete="off" ${project.description || ''} name="Description"></textarea>
                            </div>
                        </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
 <button type="button" class="btn edit-project mt-3" data-project-id="${projectSectionId}"><i class="fa-regular fa-pen-to-square"></i></button>
        <button type="button" class="btn cancel-project mt-3" data-project-id="${projectSectionId}" style="background-color: grey; color: white; width: 100px; display: none;">Cancel</button>

                                    <button type="submit" class="btn update-project mt-3"  style="background-color: #FF914D; color: white; width: 100px; display: none;">Save</button>
                                </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;
        //alert("hey");

        projectsContainer.append(projectSection);
    });

    $(".project-update-form input").prop("disabled", true);

    // Enable edit mode for a project section
    $(document).on('click', '.edit-project', function () {
        const projectId = $(this).data('project-id');
        $(`#${projectId} input`).prop('disabled', false); // Enable form fields
        $(`#projectDescription`).prop('disabled', false); // Enable form fields
        $(`#${projectId} .edit-project`).hide(); // Hide the "Edit" button
        $(`#${projectId} .update-project`).show(); // Show the "Save" button
        $(`#${projectId} .cancel-project`).show(); // Show the "Cancel" button
    });

    // Handle the "Cancel" action
    $(document).on('click', '.cancel-project', function () {
        const projectId = $(this).data('project-id');
        $(`#${projectId} input`).prop('disabled', true); // Disable form fields
        $(`#projectDescription`).prop('disabled', true); // Enable form fields
        $(`#${projectId} .edit-project`).show(); // Show the "Edit" button
        $(`#${projectId} .update-project`).hide(); // Hide the "Save" button
        $(`#${projectId} .cancel-project`).hide(); // Hide the "Cancel" button
    });

}


function populateUpdatedProject() {

    $.ajax({
        url: `/Resume/GetProjects/${resumeId}`,
        method: "GET",
        success: function (data) {
            // Call the function to populate sections with child elements
            populateProject(data);
        },
        error: function () {
            console.error("Failed to retrieve resume data.");
        }
    });
}



$(document).on("submit", ".project-form", function (e) {
    e.preventDefault();

    const form = $(this);
    const cardRemoveId = form.find(".save-project").data("card-id"); // Get the data-card-id from the submit button

    const formData = form.serialize();

    $.ajax({
        url: `/Resume/CreateProject/${resumeId}`,
        method: "POST",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Project saved successfully!");
            $(`#${cardRemoveId}`).remove();
            populateUpdatedProject();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to save project:", error);
        }
    });
});


// Handle updating a entry
$(document).on("submit", ".project-update-form", function (e) {
    e.preventDefault();

    const form = $(this);

    const formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/UpdateProject/${resumeId}`,
        method: "PUT",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Entry updated successfully!");
            populateUpdatedProject();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to update entry:", error);
        }
    });

});


// Handle deleting a entry
$(document).on('click', '.delete-entry-project', function () {
    const cardRemoveId = $(this).data('card-id');
    const entryDeleteId = $(this).data('delete-id');

    // Show the confirmation modal
    $('#confirmationModal').modal('show');

    // Handle deletion when the user clicks "Delete"
    $('#confirmDelete').on('click', function () {

        $.ajax({
            url: `/Resume/${resumeId}/DeleteProject/${entryDeleteId}`,
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

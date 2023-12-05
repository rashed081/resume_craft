$('#add-course').click(function () {
    // Increment the courseCounter to get a new unique ID
    courseCounter++;

    const courseSectionId = `courseSection-${courseCounter}`;
    const cardId = `card-${courseSectionId}`;

    const courseSection = `
                <div class="card card-body mt-3 course-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${courseSectionId}" role="button" aria-expanded="false" aria-controls="${courseSectionId}">
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
                    <div class="collapse" id="${courseSectionId}">
                        <form asp-action="SaveCourse" method="post" class="course-form" data-course-id="${courseSectionId}" >

                        <div class="course">
                            <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Title</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="Title"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Institution</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" name="InstituteName"/>
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
                              <button type="submit" class="btn save-course mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px;">Save</button>
                          </div>
                        </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

    $(".courses").append(courseSection);
});


function populateCourse(courseData) {
    const coursesContainer = $(".getCourses");
    coursesContainer.empty();

    courseData.forEach((course, index) => {
        courseCounter++;
        //courseCounter = `courseSection-${index}`;

        // Generate a unique ID for each course section
        const courseSectionId = `courseSection-${courseCounter}`;
        const cardId = `card-${courseSectionId}`;

        // Create the HTML for the course section
        const courseSection = `
                <div class="card card-body mt-3 course-section" id="${cardId}">
                    <div class="d-flex">
                        <div class="p-2 flex-grow-1"><p>${course.instituteName || ''}</p></div>
                        <div class="p-2">
                            <a data-bs-toggle="collapse" href="#${courseSectionId}" role="button" aria-expanded="false" aria-controls="${courseSectionId}">
                                <i class="fa-solid fa-angle-down"></i>
                            </a>
                        </div>
                    </div>
                    <div class="d-flex mt-2">
                        <div class=" flex-grow-1"></div>
                        <div class="">
                            <button class="btn delete delete-entry-course" data-card-id="${cardId}" data-delete-id="${course.id || ''}">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>
                    </div>
                    <div class="collapse" id="${courseSectionId}">
                        <form asp-action="UpdateCourse" method="post" class="course-update-form" data-course-id="${courseSectionId}" >

                        <input type="hidden" value="${course.id || ''}" name="Id" />

                        <div class="course">
                           <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light ">Title</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${course.title || ''}" name="Title"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">Institution</lebel>
                                <input class="form-control bg-body-secondary" required autocomplete="off" value="${course.instituteName || ''}" name="InstituteName"/>
                            </div>
                        </div>

                        <div class="row mt-4">
                            <div class="col-lg-6">
                                <lebel class="fw-light">Start</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off"  value="${formatDate(course.startDate) || ''}"  name="StartDate"/>
                            </div>
                            <div class="col-lg-6">
                                <lebel class="fw-light">End</lebel>
                                <input class="form-control bg-body-secondary" type="date" required autocomplete="off"  value="${formatDate(course.endDate) || ''}" name="EndDate"/>
                            </div>
                        </div>
                            <div class="d-flex align-items-end flex-column">
                              <div class="mt-auto p-2">
 <button type="button" class="btn edit-course mt-3" data-course-id="${courseSectionId}"><i class="fa-regular fa-pen-to-square"></i></button>
        <button type="button" class="btn cancel-course mt-3" data-course-id="${courseSectionId}" style="background-color: grey; color: white; width: 100px; display: none;">Cancel</button>

                                    <button type="submit" class="btn update-course mt-3" data-card-id="${cardId}" style="background-color: #FF914D; color: white; width: 100px; display: none;">Save</button>
                                </div>                        
                             </div>
                        </div>
                        </form>
                    </div>
                </div>
            `;

        coursesContainer.append(courseSection);
    });

    $(".course-update-form input").prop("disabled", true);

    // Enable edit mode for a course section
    $(document).on('click', '.edit-course', function () {
        const courseId = $(this).data('course-id');
        $(`#${courseId} input`).prop('disabled', false); // Enable form fields
        $(`#${courseId} .edit-course`).hide(); // Hide the "Edit" button
        $(`#${courseId} .update-course`).show(); // Show the "Save" button
        $(`#${courseId} .cancel-course`).show(); // Show the "Cancel" button
    });

    // Handle the "Cancel" action
    $(document).on('click', '.cancel-course', function () {
        const courseId = $(this).data('course-id');
        $(`#${courseId} input`).prop('disabled', true); // Disable form fields
        $(`#${courseId} .edit-course`).show(); // Show the "Edit" button
        $(`#${courseId} .update-course`).hide(); // Hide the "Save" button
        $(`#${courseId} .cancel-course`).hide(); // Hide the "Cancel" button
    });

}


function populateUpdatedCourse() {

    $.ajax({
        url: `/Resume/GetCourses/${resumeId}`,
        method: "GET",
        success: function (data) {
            // Call the function to populate sections with child elements
            populateCourse(data);
        },
        error: function () {
            console.error("Failed to retrieve resume data.");
        }
    });
}


$(document).on("submit", ".course-form", function (e) {
    e.preventDefault();

    const form = $(this);
    const cardRemoveId = form.find(".save-course").data("card-id"); // Get the data-card-id from the submit button

    const formData = form.serialize();

    $.ajax({
        url: `/Resume/CreateCourse/${resumeId}`,
        method: "POST",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Course saved successfully!");
            $(`#${cardRemoveId}`).remove();
            populateUpdatedCourse();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to save course:", error);
        }
    });
});


// Handle updating a entry
$(document).on("submit", ".course-update-form", function (e) {
    e.preventDefault();

    const form = $(this);

    //const referenceId = referenceForm.data("reference-id");
    //let resumeId = "DB5C375F-B0C8-4255-8BFF-EBC406AB0C19";
    const formData = form.serialize();
    console.log(formData);
    $.ajax({
        url: `/Resume/UpdateCourse/${resumeId}`,
        method: "PUT",
        data: formData,
        success: function (response) {
            // Handle success, e.g., display a success message
            console.log("Entry updated successfully!");
            populateUpdatedCourse();
        },
        error: function (error) {
            // Handle error, e.g., display an error message
            console.error("Failed to update entry:", error);
        }
    });

});


// Handle deleting a entry
$(document).on('click', '.delete-entry-course', function () {
    const cardRemoveId = $(this).data('card-id');
    const entryDeleteId = $(this).data('delete-id');

    // Show the confirmation modal
    $('#confirmationModal').modal('show');

    // Handle deletion when the user clicks "Delete"
    $('#confirmDelete').on('click', function () {

        $.ajax({
            url: `/Resume/${resumeId}/DeleteCourse/${entryDeleteId}`,
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

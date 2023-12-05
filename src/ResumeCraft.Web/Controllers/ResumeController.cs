using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ResumeCraft.Application.Features.Resumes.DTOs;
using ResumeCraft.Application.Features.Resumes.DTOs.Sections;
using ResumeCraft.Application.Features.Resumes.Models;
using ResumeCraft.Persistence.Features.Account.Membership;

namespace ResumeCraft.Web.Controllers
{
    public class ResumeController : BaseController
    {
        private readonly ILogger<ResumeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public ResumeController(ILogger<ResumeController> logger, UserManager<ApplicationUser> userManager,
            IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<Guid> CreateEmptyResume(Guid userId)
        {
            try
            {
                string apiUrl = $"api/v1/resumes/{userId}";

                var response = await _client.PostAsync(apiUrl, null);

                if (response.IsSuccessStatusCode)
                {
                    // Parse the response to get the newResumeId.
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseContent);

                    return RedirectToAction("Edit", result.Id);
                }
                else
                {
                    // Handle the error response.
                    throw new Exception($"Failed to create an empty resume. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        public IActionResult Edit(Guid resumeId)
        {
            //var resumeId = "75e8356b-a4a7-443a-0f94-08dbce0c8942";

            ViewBag.ResumeId = resumeId;
            return View();
        }

        [HttpGet("Resume/GetResume/{resumeId}")]
        public async Task<ResumeDTO> GetResume(Guid resumeId)
        {
            Guid userId = new Guid("36d8860d-2857-49e3-9213-08dbcda23071");
            //Guid resumeId = new Guid("75e8356b-a4a7-443a-0f94-08dbce0c8942");
            try
            {
                string apiUrl = $"{userId}/resumes/{resumeId}/template";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    ResumeDTO resume = JsonConvert.DeserializeObject<ResumeDTO>(responseContent);

                    return resume;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get references. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        #region Post operations sections

        [HttpPost("Resume/CreateExperience/{resumeId}")]
        public async Task<IActionResult> CreateExperience(Guid resumeId, ExperienceInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/experiences";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Experience added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding experience" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost("Resume/CreateEducation/{resumeId}")]
        public async Task<IActionResult> CreateEducation(Guid resumeId, EducationInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/educations";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Education added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding education" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost("Resume/CreateSkill/{resumeId}")]
        public async Task<IActionResult> CreateSkill(Guid resumeId, SkillInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/skills";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Skill added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding skill" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost("Resume/CreateCourse/{resumeId}")]
        public async Task<IActionResult> CreateCourse(Guid resumeId, CertificationInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/certifications";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Course added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding course" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost("Resume/CreateProject/{resumeId}")]
        public async Task<IActionResult> CreateProject(Guid resumeId, ProjectInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/projects";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Project added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding project" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost("Resume/CreateActivity/{resumeId}")]
        public async Task<IActionResult> CreateActivity(Guid resumeId, CurricularActivityInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/curricularActivities";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Project added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding project" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPost("Resume/CreateReference/{resumeId}")]
        public async Task<IActionResult> CreateReference(Guid resumeId, ReferenceInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/references";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PostAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Reference added successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding reference" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        #endregion

        #region Update Operation Sections
        [HttpPut("Resume/UpdateDynamic/{resumeId}")]
        public async Task<IActionResult> UpdateDynamic(Guid resumeId, ContactUpdateModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/contact/UpdateDynamic";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Contact updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding contact" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
        [HttpPut("Resume/UpdateSummary/{resumeId}")]
        public async Task<IActionResult> UpdateSummary(Guid resumeId, [FromBody] string content)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/summary";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Contact updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding contact" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
        [HttpPut("Resume/UpdateExperience/{resumeId}")]
        public async Task<IActionResult> UpdateExperience(Guid resumeId, ExperienceInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/experiences/{model.Id}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Education updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding education" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPut("Resume/UpdateEducation/{resumeId}")]
        public async Task<IActionResult> UpdateEducation(Guid resumeId, EducationInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/educations/{model.Id}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Education updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding education" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPut("Resume/UpdateSkill/{resumeId}")]
        public async Task<IActionResult> UpdateSkill(Guid resumeId, SkillInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/skills/{model.Id}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Skill updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding skill" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPut("Resume/UpdateCourse/{resumeId}")]
        public async Task<IActionResult> UpdateCourse(Guid resumeId, CertificationInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/certifications/{model.Id}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Course updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding course" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPut("Resume/UpdateProject/{resumeId}")]
        public async Task<IActionResult> UpdateProject(Guid resumeId, ProjectInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/projects/{model.Id}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Project updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding project" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPut("Resume/UpdateActivity/{resumeId}")]
        public async Task<IActionResult> UpdateActivity(Guid resumeId, CurricularActivityInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/curricularActivities/{model.Id}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Project updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding project" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpPut("Resume/UpdateReference/{resumeId}")]
        public async Task<IActionResult> UpdateReference(Guid resumeId, ReferenceInputModel model)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/references/{model.Id}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.PutAsJsonAsync(apiUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Reference updated successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while adding reference" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
        #endregion

        #region Get Sections

        [HttpGet("Resume/GetExperiences/{resumeId}")]
        public async Task<IList<ExperienceDTO>> GetExperiences(Guid resumeId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/experiences";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    IList<ExperienceDTO> experiences = JsonConvert.DeserializeObject<IList<ExperienceDTO>>(responseContent);

                    return experiences;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get experiences. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Resume/GetEducations/{resumeId}")]
        public async Task<IList<EducationDTO>> GetEducations(Guid resumeId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/educations";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    IList<EducationDTO> educations = JsonConvert.DeserializeObject<IList<EducationDTO>>(responseContent);

                    return educations;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get educations. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Resume/GetSkills/{resumeId}")]
        public async Task<IList<SkillDTO>> GetSkills(Guid resumeId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/skills";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    IList<SkillDTO> skills = JsonConvert.DeserializeObject<IList<SkillDTO>>(responseContent);

                    return skills;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get skills. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Resume/GetCourses/{resumeId}")]
        public async Task<IList<CertificationDTO>> GetCourses(Guid resumeId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/certifications";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    IList<CertificationDTO> courses = JsonConvert.DeserializeObject<IList<CertificationDTO>>(responseContent);

                    return courses;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get courses. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Resume/GetProjects/{resumeId}")]
        public async Task<IList<ProjectDTO>> GetProjects(Guid resumeId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/projects";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    IList<ProjectDTO> projects = JsonConvert.DeserializeObject<IList<ProjectDTO>>(responseContent);

                    return projects;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get projects. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Resume/GetActivities/{resumeId}")]
        public async Task<IList<CurricularActivityDTO>> GetActivities(Guid resumeId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/curricularActivities";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    IList<CurricularActivityDTO> activities = JsonConvert.DeserializeObject<IList<CurricularActivityDTO>>(responseContent);

                    return activities;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get activities. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("Resume/GetReferences/{resumeId}")]
        public async Task<IList<ReferenceDTO>> GetReferences(Guid resumeId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/references";

                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    IList<ReferenceDTO> references = JsonConvert.DeserializeObject<IList<ReferenceDTO>>(responseContent);

                    return references;
                }
                else
                {
                    // Handle the error response here.
                    throw new Exception($"Failed to get references. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }

        #endregion

        #region Delete

        [HttpDelete("Resume/{resumeId}/DeleteExperience/{experienceId}")]
        public async Task<IActionResult> DeleteExperience(Guid resumeId, Guid experienceId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/experiences/{experienceId}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Entry deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting entry" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpDelete("Resume/{resumeId}/DeleteEducation/{educationId}")]
        public async Task<IActionResult> DeleteEducation(Guid resumeId, Guid educationId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/educations/{educationId}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Entry deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting entry" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpDelete("Resume/{resumeId}/DeleteSkill/{skillId}")]
        public async Task<IActionResult> DeleteSkill(Guid resumeId, Guid skillId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/skills/{skillId}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Entry deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting entry" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpDelete("Resume/{resumeId}/DeleteCourse/{courseId}")]
        public async Task<IActionResult> DeleteCourse(Guid resumeId, Guid courseId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/certifications/{courseId}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Entry deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting entry" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpDelete("Resume/{resumeId}/DeleteProject/{projectId}")]
        public async Task<IActionResult> DeleteProject(Guid resumeId, Guid projectId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/projects/{projectId}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Entry deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting entry" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpDelete("Resume/{resumeId}/DeleteActivity/{activityId}")]
        public async Task<IActionResult> DeleteActivity(Guid resumeId, Guid activityId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/curricularActivities/{activityId}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Entry deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting entry" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpDelete("Resume/{resumeId}/DeleteReference/{referenceId}")]
        public async Task<IActionResult> DeleteReference(Guid resumeId, Guid referenceId)
        {
            try
            {
                string apiUrl = $"resumes/{resumeId}/references/{referenceId}";

                // Send the HTTP POST request to the API endpoint.
                HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API call was successful.
                    string responseContent = await response.Content.ReadAsStringAsync();

                    return Json(new { success = true, message = "Entry deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Error occurred while deleting entry" });
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, if any.
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        #endregion

        #region Image Crop

        public IActionResult ImageCrop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImageCrop(IFormFile imageFile, ApplicationUser user)
        {
            try
            {
                using (var image = Image.Load(imageFile.OpenReadStream()))
                {
                    var fileName = $"{user.Id}.jpeg";
                    var imageDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"));
                    var fullPath = Path.Combine(imageDir, fileName);

                    user.ImageUrl = $"wwwroot/images/{fileName}";
                    image.Mutate(x => x.Resize(300, 300));
                    image.SaveAsJpeg(fullPath);

                    _userManager.UpdateAsync(user);
                    TempData["message"] = "Image Uploaded successfully.";
                }
                return Json(new { Message = "OK" /**/ });
            }
            catch (Exception) { return Json(new { Message = "ERROR" }); }
        }

        #endregion
    }
}

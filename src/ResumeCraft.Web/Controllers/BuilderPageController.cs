using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using ResumeCraft.Application.Features.CoverLetters.DTOs;
using ResumeCraft.Application.Features.Resumes.DTOs;
using System.Text.Json;

namespace ResumeCraft.Web.Controllers
{
    public class BuilderPageController : Controller
    {
        private readonly IConverter _converter;
        private readonly string _stringResumeJsonData;
        private readonly string _stringCoverLetterJsonData;

        public BuilderPageController(IConverter converter)
        {
            _converter = converter;
            _stringResumeJsonData =
                @"
{
  ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
  ""Name"": ""John Doe"",
  ""UserId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
  ""CoverLetterId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
  ""SelectedTemplateId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
  ""Contact"": {
    ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
    ""FullName"": ""John Doe"",
    ""FirstName"": ""John"",
    ""LastName"": ""Doe"",
    ""DateOfBirth"": ""2023-10-13T23:28:45.023Z"",
    ""ImageUrl"": ""https://alumniassociation.mayo.edu/wp-content/uploads/2023/03/Nagaraja_Vinayak_30055721_202107070809.jpg"",
    ""Address"": ""123 Main St, Anytown"",
    ""Socials"": [
      {
        ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
        ""PlatformName"": ""LinkedIn"",
        ""ProfileUrl"": ""https://www.linkedin.com/in/johndoe""
      },
      {
        ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
        ""PlatformName"": ""Twitter"",
        ""ProfileUrl"": ""https://twitter.com/johndoe""
      }
    ]
  },
  ""Summary"": {
    ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
    ""Content"": ""A passionate professional with diverse skills.""
  },
  ""Awards"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""InstituteName"": ""ABC University"",
      ""Title"": ""Outstanding Student Award""
    }
  ],
  ""Certifications"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""InstituteName"": ""XYZ Institute"",
      ""StartDate"": ""2023-10-13T23:28:45.023Z"",
      ""EndDate"": ""2023-10-13T23:28:45.023Z"",
      ""Title"": ""Certified Professional""
    }
  ],
  ""CurricularActivities"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""StartDate"": ""2023-10-13T23:28:45.023Z"",
      ""EndDate"": ""2023-10-13T23:28:45.023Z"",
      ""Title"": ""Student Council Member"",
      ""Organization"": ""XYZ Organization""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""StartDate"": ""2022-05-01T10:00:00.000Z"",
      ""EndDate"": ""2022-12-31T23:59:59.999Z"",
      ""Title"": ""Debate Club Member"",
      ""Organization"": ""ABCD Organization""
    }
  ],
  ""Educations"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""ResumeId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""InstituteName"": ""ABC University"",
      ""City"": ""Anytown"",
      ""Country"": ""USA"",
      ""FieldOfStudy"": ""Computer Science"",
      ""Grade"": ""A+"",
      ""StartDate"": ""2023-10-13T23:28:45.023Z"",
      ""EndDate"": ""2023-10-13T23:28:45.023Z""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""ResumeId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""InstituteName"": ""ABC University"",
      ""City"": ""Anytown"",
      ""Country"": ""USA"",
      ""FieldOfStudy"": ""Computer Science"",
      ""Grade"": ""A+"",
      ""StartDate"": ""2023-10-13T23:28:45.023Z"",
      ""EndDate"": ""2023-10-13T23:28:45.023Z""
    }
  ],
  ""Experiences"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""CompanyName"": ""TechCorp Inc."",
      ""Designation"": ""Software Engineer"",
      ""KeyAchievement"": ""Led a successful project team."",
      ""StartDate"": ""2023-10-13T23:28:45.023Z"",
      ""EndDate"": ""2023-10-13T23:28:45.023Z""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""CompanyName"": ""ABC Corporation"",
      ""Designation"": ""Junior Developer"",
      ""KeyAchievement"": ""Implemented new features."",
      ""StartDate"": ""2022-02-15T08:00:00.000Z"",
      ""EndDate"": ""2023-09-30T17:30:00.000Z""
    }
  ],
  ""Interests"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""Name"": ""Photography""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""Name"": ""Hiking""
    }
  ],
  ""Projects"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""Description"": ""Developed a web application for a client."",
      ""ProjectName"": ""Web App Project"",
      ""RepositoryUrl"": ""https://github.com/user/project""
    }
  ],
  ""Publications"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""InstituteName"": ""Research Institute"",
      ""Title"": ""A Study on Artificial Intelligence"",
      ""PublishedDate"": ""2023-10-13T23:28:45.023Z"",
      ""PublishedUrl"": ""https://example.com/research/paper123.pdf""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""InstituteName"": ""Research Institute"",
      ""Title"": ""A Study on Artificial Intelligence"",
      ""PublishedDate"": ""2023-10-13T23:28:45.023Z"",
      ""PublishedUrl"": ""https://example.com/research/paper123.pdf""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""InstituteName"": ""Research Institute"",
      ""Title"": ""A Study on Artificial Intelligence"",
      ""PublishedDate"": ""2023-10-13T23:28:45.023Z"",
      ""PublishedUrl"": ""https://example.com/research/paper123.pdf""
    }
  ],
  ""References"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""SupervisorDesignation"": ""Project Manager"",
      ""SupervisorEmail"": ""supervisor@example.com"",
      ""SupervisorInstituteName"": ""TechCorp Inc."",
      ""SupervisorName"": ""Alice Smith"",
      ""SupervisorPhone"": ""+1234567890""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""SupervisorDesignation"": ""Project Manager"",
      ""SupervisorEmail"": ""supervisor@example.com"",
      ""SupervisorInstituteName"": ""TechCorp Inc."",
      ""SupervisorName"": ""Alice Smith"",
      ""SupervisorPhone"": ""+1234567890""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""SupervisorDesignation"": ""Project Manager"",
      ""SupervisorEmail"": ""supervisor@example.com"",
      ""SupervisorInstituteName"": ""TechCorp Inc."",
      ""SupervisorName"": ""Alice Smith"",
      ""SupervisorPhone"": ""+1234567890""
    }
  ],
  ""Skills"": [
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""ResumeId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""Name"": ""JavaScript""
    },
    {
      ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""ResumeId"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
      ""Name"": ""C#""
    }
  ]
}

";
            _stringCoverLetterJsonData =
                @"
{
  ""Id"": ""3fa85f64-5717-4562-b3fc-2c963f66afa6"",
  ""ToWhom"": ""Nobir Hossain"",
  ""ApplicantsFullName"": ""John Doe"",
  ""CompanyAddress"": ""123 Company St, Anytown"",
  ""JobPosition"": ""Software Developer"",
  ""LetterContent"": ""I am writing to express my interest in the Software Developer position at your company. With a strong background in web development, I am excited about the opportunity to contribute to your team.</p><p>Throughout my career, I have gained experience in various programming languages and technologies, including <em>JavaScript</em>, <em>HTML</em>, and <em>CSS</em>. I have a proven track record of delivering high-quality software solutions and collaborating with cross-functional teams.</p><p>I look forward to the possibility of joining your company and contributing to your ongoing success. Thank you for considering my application.</p>"",
  ""ApplyingDate"": ""2023-10-16T07:48:39.586Z""
}
";
        }

        public async Task<IActionResult> Template(string templateName)
        {
            dynamic data;
            if (templateName.StartsWith("Resume"))
            {
                data = await Task.FromResult(JsonSerializer.Deserialize<ResumeDTO>(_stringResumeJsonData));
            }
            else
            {
                data = await Task.FromResult(JsonSerializer.Deserialize<CoverLetterDTO>(_stringCoverLetterJsonData));
            }

            return View(templateName, data);
        }

        private async Task<FileDto> GeneratePdfBytesAsync(string? htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings
                    {
                        Top = 0,
                        Bottom = 0,
                        Left = 0,
                        Right = 0
                    },
                    DPI = 300,
                },
                Objects =
                {
                    new ObjectSettings()
                    {
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HtmlContent = htmlContent,
                        LoadSettings = { ZoomFactor = 2, }
                    }
                }
            };

            return await Task.FromResult(new FileDto("pdf.pdf", _converter.Convert(doc)));
        }

        [HttpPost]
        public async Task<IActionResult> Pdf([FromBody] dynamic data)
        {
            var jsonData = JsonSerializer.Deserialize<JsonData>(data);
            var file = await GeneratePdfBytesAsync(jsonData.Payload);

            Response.Headers.Add("rct_filename", file.FileName);

            var resutls = File(file.FileBytes, "application/pdf", file.FileName);

            return await Task.FromResult(resutls);
        }

        public IActionResult Index(string templateName)
        {
            return View("Index", templateName);
        }
    }

    public class FileDto
    {
        public string FileName { get; set; }
        public byte[] FileBytes { get; set; }

        public FileDto(string fileName, byte[] fileBytes)
        {
            FileName = fileName;
            FileBytes = fileBytes;
        }
    }

    public class JsonData
    {
        public string? Payload { get; set; }
    }
}

namespace ResumeCraft.Domain.Entities.EnumCollections
{
    public enum Gender : byte
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum Level
    {
        Beginner = 1,
        Experienced = 2,
        Expert = 3
    }

    public enum UserOperation
    {
        // Award
        AddAward = 1,
        DeleteAward = 2,
        UpdateAward = 3,

        // Certification
        AddCertification = 4,
        DeleteCertification = 5,
        UpdateCertification = 6,

        // CoverLetter
        AddCoverLetter = 7,
        DeleteCoverLetter = 8,
        UpdateCoverLetter = 9,

        // CoverLetterTemplate
        AddCoverLetterTemplate = 10,
        DeleteCoverLetterTemplate = 11,
        UpdateCoverLetterTemplate = 12,

        // CurricularActivity
        AddCurricularActivity = 13,
        DeleteCurricularActivity = 14,
        UpdateCurricularActivity = 15,

        // Education
        AddEducation = 16,
        DeleteEducation = 17,
        UpdateEducation = 18,

        // Experience
        AddExperience = 19,
        DeleteExperience = 20,
        UpdateExperience = 21,

        // Interest
        AddInterest = 22,
        DeleteInterest = 23,
        UpdateInterest = 24,

        // PersonalDetail
        AddPersonalDetail = 25,
        DeletePersonalDetail = 26,
        UpdatePersonalDetail = 27,

        // Project
        AddProject = 28,
        DeleteProject = 29,
        UpdateProject = 30,

        // Publication
        AddPublication = 31,
        DeletePublication = 32,
        UpdatePublication = 33,

        // Reference
        AddReference = 34,
        DeleteReference = 35,
        UpdateReference = 36,

        // Resume
        AddResume = 37,
        DeleteResume = 38,
        UpdateResume = 39,

        // ResumeTemplate
        AddResumeTemplate = 40,
        DeleteResumeTemplate = 41,
        UpdateResumeTemplate = 42,

        // Skill
        AddSkill = 43,
        DeleteSkill = 44,
        UpdateSkill = 45,

        // Social
        AddSocial = 46,
        DeleteSocial = 47,
        UpdateSocial = 48,

        // Summary
        AddSummary = 49,
        DeleteSummary = 50,
        UpdateSummary = 51,

        // UserActivity
        AddUserActivity = 52,
        DeleteUserActivity = 53,
        UpdateUserActivity = 54,
    }
}

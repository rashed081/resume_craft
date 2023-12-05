using ResumeCraft.Domain.Entities.EnumCollections;

namespace ResumeCraft.Application.Features.Account.DTOs
{
    public record struct ApplicationUserSearchDTO
    {
        public DateTime? DateOfBirthFrom { get; set; }
        public DateTime? DateOfBirthTo { get; set; }
        public Gender Gender { get; set; }

        /// <summary>
        /// <para>
        /// FullName
        /// </para>
        /// <seealso>See class <c>ApplicationUserDTO</c></seealso>
        /// </summary>
        public string? ApplicationUserFullName { get; set; }

        /// <summary>
        /// <para>
        /// TemplateName
        /// </para>
        /// <seealso>See class <c>CoverLetterDTO</c></seealso>
        /// </summary>
        public string? CoverLetterTemplateName { get; set; }

        /// <summary>
        /// <para>
        /// TemplateName
        /// </para>
        /// <seealso>See class <c>ResumeTemplateDTO</c></seealso>
        /// </summary>
        public string? ResumeTemplateName { get; set; }

        /// <summary>
        /// <para>
        /// Name
        /// </para>
        /// <seealso>See class <c>ResumeDTO</c></seealso>
        /// </summary>
        public string? ResumeName { get; set; }

        /// <summary>
        /// <para>
        /// UserName
        /// </para>
        /// <seealso>See class <c>IdentityUser</c></seealso>
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// <para>
        /// FullName
        /// </para>
        /// <seealso>See class <c>ApplicationUser</c></seealso>
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// <para>
        /// Email
        /// </para>
        /// <seealso>See class <c>IdentityUser</c></seealso>
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// <para>
        /// Phone
        /// </para>
        /// <seealso>See class <c>IdentityUser</c></seealso>
        /// </summary>
        public string? Phone { get; set; }
    }
}

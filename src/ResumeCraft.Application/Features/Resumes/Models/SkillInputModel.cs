using ResumeCraft.Domain.Entities.EnumCollections;
using System.ComponentModel.DataAnnotations;

namespace ResumeCraft.Application.Features.Resumes.Models;

public class SkillInputModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Skill Name field can not be empty")]
    public string Name { get; set; } = null!;
    public Level? Level { get; set; }
}

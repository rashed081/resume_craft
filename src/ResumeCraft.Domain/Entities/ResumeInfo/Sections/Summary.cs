using ResumeCraft.Domain.Entities.Base;

namespace ResumeCraft.Domain.Entities.ResumeInfo.Sections
{
    public class Summary : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }

        public Guid ResumeId { get; set; }
        public Resume Resume { get; set; } = null!;

        public object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}

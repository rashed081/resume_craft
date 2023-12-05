namespace ResumeCraft.Domain.Entities.Base
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}

namespace ResumeCraft.Domain.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}

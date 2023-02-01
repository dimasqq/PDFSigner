namespace PDFSigner.Managers.Interfaces
{
    public interface IBaseManager
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}
